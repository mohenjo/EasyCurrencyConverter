using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Diagnostics;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HNP.Utils
{
    /// <summary>
    /// 환율 코드, 설명, 갱신 일자, 환율을 나타내는 클래스입니다. 환율은 기준환율(USD)에 대한 변환 비율을 의미합니다.
    /// </summary>
    public class CurrencyRate
    {
        // 국가 코드 (대문자)
        public string NationalCode { get; } = string.Empty;

        // 국가 코드에 대한 설명
        public string Description { get; } = string.Empty;

        // 환율 정보 갱신 시간
        public string Date { get; } = string.Empty;

        // 수집 기준 환율(USD)에 대한 상대적 비율: 예> 1 USD = Rate (in 국가코드)
        public double Rate { get; } = 0.0;

        /// <summary>
        /// 국가 코드, 국가 코드 설명, 갱신 시간, 기준 국카 코드 대비 환율을 이용하여 클래스를 구성합니다.
        /// </summary>
        /// <param name="nationalCode">국가 코드</param>
        /// <param name="description">국가 코드에 대한 설명</param>
        /// <param name="date">환율 정보 갱신 시간</param>
        /// <param name="rate">기준 국가 코드(USD) 대비 환율</param>
        public CurrencyRate(string nationalCode, string description, string date, double rate)
        {
            this.NationalCode = nationalCode;
            this.Description = description;
            this.Date = date;
            this.Rate = rate;
        }

        /// <summary>
        /// 두 <c>CurrencyRate</c> 클래스 간의 환율 변환 금액을 반홥합니다. 
        /// 출발 환율 클래스의 금액이 도착 환율로 변환된 값입니다.
        /// </summary>
        /// <param name="crA">출발 환율 클래스</param>
        /// <param name="amountA">출발 환율의 보유 금액</param>
        /// <param name="crB">도착 환율 클래스</param>
        /// <returns></returns>
        public static double GetConvertedValue(CurrencyRate crA, double amountA, CurrencyRate crB)
        {
            double unitRate = crB.Rate / crA.Rate; // 두 통화 간 변환 비율
            double result = unitRate * amountA;

            return result;
        }

        /// <summary>
        /// 웹에서 환율 정보를 읽어 <c>CurrencyRate</c> 클래스의 리스트를 반환합니다.
        /// <para>참조 URL: <see cref="http://www.floatrates.com/json-feeds.html"/></para>
        /// </summary>
        /// <returns></returns>
        public static List<CurrencyRate> InitializeFromWeb()
        {
            // ----- 웹 주소에서 환율 데이터 (JSON 형식 스트링) 읽어 오기
            string url = @"http://www.floatrates.com/daily/usd.json";
            string JsonString = string.Empty;
            try
            {
                // WebCLient는 IDisposable이므로 반드시 리소스 해제 필요
                using (WebClient wc = new WebClient())
                {
                    JsonString = wc.DownloadString(url);
                }
            }
            catch (Exception ex)
            {
                // Debug
                Debug.WriteLine($"WebClient 클래스를 이용하여 {url}에서 환율정보(json)를 읽어 오는데 실패했습니다.");
                Debug.Indent();
                Debug.WriteLine($"- {ex.Message}");
                Debug.Unindent();

                throw;
            }

            // ----- 읽어온 JSON 형식 스트링을 파싱
            JObject jObj = new JObject();
            try
            {
                jObj = JObject.Parse(JsonString);
            }
            catch (JsonReaderException ex)
            {
                // Debug
                Debug.WriteLine($"Json 문자열을 파싱하는 도중 예외가 발생했습니다.");
                Debug.Indent();
                Debug.WriteLine($"- {ex.Message}");
                Debug.Unindent();

                throw;
            }

            // ----- JSON 객체에서 필요 정보 수집
            List<CurrencyRate> crs = new List<CurrencyRate>();

            // 수집 기준 환율(USD)은 수집된 JSON에 포함되지 않음. 따라서 별도로 추가함.
            string usdDate = string.Empty; // USD 환율 갱신 일자

            // JSON 개체에 각각에 대해 key(= 국가코드)를 얻고, value (정보를 담고 있는 JToken 개체)에서 필요 정보 수집
            // ! 아래 JObject 사용 방법 기억할 것
            foreach (KeyValuePair<string, JToken> keyval in jObj)
            {
                string nationalCode = keyval.Key.ToUpper();
                JToken jtkn = keyval.Value;
                string description = jtkn["name"].ToString();
                string date = jtkn["date"].ToString();
                double rate = (double)jtkn["rate"];
                crs.Add(new CurrencyRate(nationalCode, description, date, rate));
                usdDate = date; // USD 환율 갱신 일자
            }

            // 수집 기준 환율 정보 추가
            crs.Add(new CurrencyRate("USD", "U.S. Dollar", usdDate, 1.0));

            return crs;
        }
    }
}
