namespace calculation
{
    public partial class Form1 : Form
    {
        //txtAlgorithm�������
        //txtResult�������/�����

        //indexΪ1�������������� + - * / ���� �� = 
        //�У�123+    123=

        //indexΪ2��������������� + - * /����һ�� ������ =
        //�У�123+2=
        private int index = 0;
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// �������0~9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn0_Click(object sender, EventArgs e)
        {
            if (index == 1)
            {
                //index==1 ������������
                txtResult.Text = "0";
                index = 0;
            }
            if (index == 2)
            {
                //index==2 �������������������
                btnReset_Click(sender, e);
                index = 0;
            }
            //��ȡ�¼�Դ
            Button thisbtn = sender as Button;
            if (txtResult.Text.Length == 1 && txtResult.Text == "0")
            {
                txtResult.Text = thisbtn.Text;
                return;
            }

            txtResult.Text += thisbtn.Text;
        }
        /// <summary>
        /// ���"."
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDian_Click(object sender, EventArgs e)
        {
            //�ж��������Ƿ������.��
            //���������.�� �����ٴ���ӡ�.��
            if (txtResult.Text.Contains(btnDian.Text))
            {
                return;
            }
            txtResult.Text += btnDian.Text;
        }

        /// <summary>
        /// �����C��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            //����������������
            txtAlgorithm.Text = "";
            txtResult.Text = "0";
        }
        /// <summary>
        /// �����CE��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnResetResult_Click(object sender, EventArgs e)
        {
            //���������
            txtResult.Text = "0";
        }

        /// <summary>
        /// ������
        /// </summary>
        /// <returns></returns>
        private decimal Result()
        {
            //��ȡ��������
            string symbol = txtAlgorithm.Text.Substring(txtAlgorithm.Text.Length - 1);
            //��ȡ���������
            decimal num1 = Convert.ToDecimal(txtAlgorithm.Text.Substring(0, txtAlgorithm.Text.Length - 1));
            //��ȡ���������
            decimal num2 = Convert.ToDecimal(txtResult.Text);
            decimal result = 0;
            try
            {
                //���ݼ����ķ��Ž��ж�Ӧ�ļ���
                switch (symbol)
                {
                    case "+": result = num1 + num2; break;
                    case "-": result = num1 - num2; break;
                    case "��": result = num1 * num2; break;
                    case "��": result = num1 / num2; break;
                    default:
                        break;
                }
            }
            catch
            {
                MessageBox.Show("��������Ϊ0");
            }
            //���ؼ�����
            return result;
        }

        /// <summary>
        /// ���"+,-,��,��"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //�ж�������������Ϊ�Ƿ���.
            if (txtResult.Text.Substring(txtResult.Text.Length - 1) == btnDian.Text)
            {
                //�����ɾ����
                txtResult.Text = txtResult.Text.Substring(0, txtResult.Text.Length - 1);
            }

            Button thisBtn = sender as Button;

            //�жϼ������Ƿ�Ϊ�ղ��Ҳ�������=��
            //��1��           ��2��������Ϊ�գ� ��3����������Ϊ�� ��������=����
            //������1��123+       ������2��     ������3��123=
            //������1��2          ������2��2    ������3��2
            if (txtAlgorithm.Text != "" && !txtAlgorithm.Text.Contains("="))
            {
                //�����Ϊ�ղ��Ҳ�������=�� ���м���
                decimal result = Result();
                //���������Ϊ������
                txtResult.Text = result.ToString();

                //��ʱ������1��123+
                //��ʱ������1��125
            }

            //���������Ϊ����������ӡ�+ - * /����Ӧ����
            txtAlgorithm.Text = txtResult.Text + thisBtn.Text;
            //�����
            //��������1��125+  ������2��2+  ������3��2+  
            //���������1��125   ������2��2   ������4��2

            index = 1;
        }

        /// <summary>
        /// ���"="
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnResult_Click(object sender, EventArgs e)
        {
            #region �����=�� �롰.���Ĳ���

            //�ж�������������Ƿ�Ϊ��.��
            //�У�
            //�����
            //����� 123.
            if (txtResult.Text.Substring(txtResult.Text.Length - 1) == btnDian.Text)
            {
                //����ɾ��
                txtResult.Text = txtResult.Text.Substring(0, txtResult.Text.Length - 1);
                //�����
                //�����123
                //�����123
            } 
            #endregion

            //�жϼ����������Ϊ�Ƿ񲻰�����=�� ���Ҽ����Ϊ��
            //�У�
            //����� 123+
            //������   2
            if (txtAlgorithm.Text != "" && !txtAlgorithm.Text.Contains("="))
            {
                //������
                decimal result = Result();
                txtAlgorithm.Text += txtResult.Text + "=";
                txtResult.Text = result.ToString();
                //�����
                //�����123+2=
                //�����125

                //��ʱ��һ�ε������ ����������������
                index = 2;
                
            }

            //�У�������Ϊ�գ���    ��2�������Ϊ�� ������=��
            //�����              ������2�� 123=
            //����� 123          ������2�� 2
            else
            {
                txtAlgorithm.Text = txtResult.Text;
                txtAlgorithm.Text += "=";
                index = 1;
                //�����
                //�����123=      ������2�� 2=
                //�����123       ������2�� 2
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //MessageBox.Show((0.1+0.2).ToString());
        }

        /// <summary>
        /// ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnZhengFu_Click(object sender, EventArgs e)
        {
            //�ж��������Ƿ����0
            if (Convert.ToDecimal(txtResult.Text) > 0)
            {
                //��Ӹ���
                txtResult.Text = "-" + txtResult.Text;
            }
            else if (Convert.ToDecimal(txtResult.Text) < 0)
            {
                //ɾ������
                txtResult.Text = txtResult.Text.Substring(1);
            }
        }

        /// <summary>
        /// ����������˸��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnYu_Click(object sender, EventArgs e)
        {
            //���������Ϊ0 ���˸�
            if (txtResult.Text=="0")
            {
                return;
            }
            //���������Ϊ1λ�� ��Ϊ0
            else if (txtResult.Text.Length==1)
            {
                txtResult.Text = "0";
            }
            //����ȥ�����������һλ��
            else
            {
                txtResult.Text= txtResult.Text.Substring(0, txtResult.Text.Length - 1);
            }
        }
    }
}