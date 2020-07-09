using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HNP.Utils;

namespace EasyCurrencyConverter
{
    sealed class Globals
    {
        public readonly static string WindowTitle = "간이 환율 변환기";
        public readonly static string ParseUrl = @"http://www.floatrates.com/daily/usd.json";
        public static bool IsAccesible { get; set; } = false; // 폼의 콘트롤 구성이 끝나서 액세스가 가능한지 여부

        // 웹 자료로 구성한 CurrencyRate 클래스들의 리스트
        public static List<CurrencyRate> crs = new List<CurrencyRate>();
    }
}
