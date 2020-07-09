using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Diagnostics;
using HNP.Utils;


namespace TestWork
{
    class Program
    {
        static void Main(string[] args)
        {
            // 웹에서 환율 정보를 읽어서, CurrencyRate 클래스의 리스트를 구성
            List<CurrencyRate> crs = CurrencyRate.InitializeFromWeb();

            // 임의 두 환율간 변환 테스트
            int idxA = 0;
            int idxB = 0;
            for (int idx = 0; idx < crs.Count; idx++)
            {
                if (crs[idx].NationalCode.Equals("JPY")) { idxA = idx; }
                if (crs[idx].NationalCode.Equals("KRW")) { idxB = idx; }
            }
            CurrencyRate crA = crs[idxA];
            CurrencyRate crB = crs[idxB];
            double amountA = 2000;
            double result = CurrencyRate.GetConvertedValue(crA, amountA, crB);
            Console.WriteLine($"출발 환율: {crA.NationalCode} ({crA.Description}) - USD 기준 환율비는 {crA.Rate} (updated at: {crA.Date})입니다.");
            Console.WriteLine($"도착 환율: {crB.NationalCode} ({crB.Description}) - USD 기준 환율비는 {crB.Rate} (updated at: {crB.Date})입니다.");
            Console.WriteLine($"변환결과: {amountA} {crA.NationalCode} = {result} {crB.NationalCode}");
            Console.ReadKey();
        }

    }
}
