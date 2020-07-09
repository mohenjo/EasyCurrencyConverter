using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using HNP.Utils;

namespace EasyCurrencyConverter
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            // 폼 초기화
            SetupUI();

            // 환율 정보 데이터 구성
            ReadCurrencyInfo();

            // 컨트롤 내용 초기화
            SetupControls();
        }

        #region 사용자 정의 메소드

        // 폼 초기화
        public void SetupUI()
        {
            this.Text = Globals.WindowTitle;
        }

        // 콘트롤 내용 초기화
        public void SetupControls()
        {
            // --- 콤보박스 내용 구성
            List<string> comboboxContents = new List<string>();
            foreach (CurrencyRate cr in Globals.crs)
            {
                string content = cr.NationalCode + ": " + cr.Description;
                comboboxContents.Add(content);
            }
            comboboxContents.Sort();
            cmbA.Items.AddRange(comboboxContents.ToArray());
            cmbA.SelectedIndex = cmbA.FindString("USD");
            cmbB.Items.AddRange(comboboxContents.ToArray());
            cmbB.SelectedIndex = cmbB.FindString("KRW");

            // --- 환율 정보 갱신 시간 표시
            // 환율 목록의 첫번째 내용에서 갱신 시간 구함
            lblLastUpdated.Text = $"최종 정보 갱신: {Globals.crs[0].Date.Trim()} (일 단위 갱신)";

            // --- 저작자 표시
            lblAuthor.Text = "Powered 2018 by Haennim Park (https://www.github.com/mohenjo)";

            // --- 텍스트 박스 내용 초기화
            txtA.Text = $"{1:#,##0.00}";
            SetTextboxValue();

            // --- 툴팁 설정
            tooltip.SetToolTip(txtA, "엔터키를 눌러야 값이 반영됩니다.");
        }

        // 환율 정보 데이터 구성
        public void ReadCurrencyInfo()
        {
            try
            {
                Globals.crs = CurrencyRate.InitializeFromWeb();
            }
            catch (Exception ex)
            {
                String msg = "환율 정보 데이터를 구성하는 중에 오류가 발생했습니다."
                    + Environment.NewLine + $"- 예외: {ex.Message}"
                    + Environment.NewLine + "다시 시도하거나, 다음 주소가 정상적으로 응답하는지 확인해야 합니다."
                    + Environment.NewLine + $"- URL: {Globals.ParseUrl}";
                MessageBox.Show(msg, Globals.WindowTitle, MessageBoxButtons.OK);
                Application.Exit();
            }
        }

        // 환율을 계산하여 텍스트 박스 내용 갱신
        public void SetTextboxValue() // A => B로의 변환
        {
            // --- 출발, 도착 콤보박스 선택 내용 가져오기 (국가 코드)
            // 각 콤보박스 선택 문자열에서 국가 코드 추출
            string nationalCodeSrc = cmbA.SelectedItem.ToString().Split(new char[] { ':' })[0];
            string nationalCodeTgt = cmbB.SelectedItem.ToString().Split(new char[] { ':' })[0];

            // --- 각 콤보박스 선택의 국가코드에 해당하는 클래스 가져오기
            CurrencyRate crSrc = null;
            CurrencyRate crTgt = null;
            foreach (CurrencyRate cs in Globals.crs)
            {
                if (cs.NationalCode.Equals(nationalCodeSrc)) { crSrc = cs; }
                if (cs.NationalCode.Equals(nationalCodeTgt)) { crTgt = cs; }
            }

            // --- 출발 금액 가져오기
            // 출발 텍스트 박스의 금액 가져오기
            string amountText = txtA.Text.Replace(",", "");
            double amount = double.Parse(amountText); // 변환할 금액

            // --- 변환 금액 계산
            double convertedAmount = CurrencyRate.GetConvertedValue(crSrc, amount, crTgt);

            // --- 텍스트 박스에 표시
            string convertedAmountText = $"{convertedAmount:#,##0.00}";
            txtB.Text = convertedAmountText;
        }

        #endregion

        private void frmMain_Shown(object sender, EventArgs e)
        {
            Globals.IsAccesible = true; // 폼의 로드가 완료되고 표시되었으므로 콘트롤 액세스 가능
        }

        private void cmbA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Globals.IsAccesible) { return; }
            SetTextboxValue();
        }

        private void cmbB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Globals.IsAccesible) { return; }
            SetTextboxValue();
        }

        private void txtA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) // 텍스트박스 A에 엔터키가 입력되면
            {
                e.Handled = true; // 엔터키 처리 시 비프 음을 막음
                // 입력된 숫자를 조정하여 포맷 출력
                StringBuilder newText = new StringBuilder();
                foreach (char chr in txtA.Text)
                {
                    if (char.IsDigit(chr) || chr == '.')
                    {
                        newText.Append(chr);
                    }
                }
                txtA.Text = $"{double.Parse(newText.ToString()):#,##0.00}";
                // 정리된 텍스트 A에 대해 환율 변환 진행
                SetTextboxValue();
            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            string txtABackup = txtA.Text;
            int cmbABackup = cmbA.SelectedIndex;

            txtA.Text = txtB.Text;
            cmbA.SelectedIndex = cmbB.SelectedIndex;

            txtB.Text = txtABackup;
            cmbB.SelectedIndex = cmbABackup;
        }
    }
}
