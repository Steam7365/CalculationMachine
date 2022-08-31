namespace calculation
{
    public partial class Form1 : Form
    {
        //txtAlgorithm：计算框
        //txtResult：输入框/结果框

        //index为1情况：计算框里有 + - * / 或者 有 = 
        //列：123+    123=

        //index为2情况：计算框里包含 + - * /其中一个 并还有 =
        //列：123+2=
        private int index = 0;
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 点击数字0~9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn0_Click(object sender, EventArgs e)
        {
            if (index == 1)
            {
                //index==1 将输入项重置
                txtResult.Text = "0";
                index = 0;
            }
            if (index == 2)
            {
                //index==2 将输入项与计算项重置
                btnReset_Click(sender, e);
                index = 0;
            }
            //获取事件源
            Button thisbtn = sender as Button;
            if (txtResult.Text.Length == 1 && txtResult.Text == "0")
            {
                txtResult.Text = thisbtn.Text;
                return;
            }

            txtResult.Text += thisbtn.Text;
        }
        /// <summary>
        /// 点击"."
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDian_Click(object sender, EventArgs e)
        {
            //判断输入项是否包含“.”
            //如果包含”.“ 则不能再次添加“.”
            if (txtResult.Text.Contains(btnDian.Text))
            {
                return;
            }
            txtResult.Text += btnDian.Text;
        }

        /// <summary>
        /// 点击“C”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReset_Click(object sender, EventArgs e)
        {
            //清空输入项与计算项
            txtAlgorithm.Text = "";
            txtResult.Text = "0";
        }
        /// <summary>
        /// 点击“CE”
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnResetResult_Click(object sender, EventArgs e)
        {
            //清空输入项
            txtResult.Text = "0";
        }

        /// <summary>
        /// 计算结果
        /// </summary>
        /// <returns></returns>
        private decimal Result()
        {
            //获取计算框符号
            string symbol = txtAlgorithm.Text.Substring(txtAlgorithm.Text.Length - 1);
            //获取计算框数字
            decimal num1 = Convert.ToDecimal(txtAlgorithm.Text.Substring(0, txtAlgorithm.Text.Length - 1));
            //获取输入框数字
            decimal num2 = Convert.ToDecimal(txtResult.Text);
            decimal result = 0;
            try
            {
                //根据计算框的符号进行对应的计算
                switch (symbol)
                {
                    case "+": result = num1 + num2; break;
                    case "-": result = num1 - num2; break;
                    case "×": result = num1 * num2; break;
                    case "÷": result = num1 / num2; break;
                    default:
                        break;
                }
            }
            catch
            {
                MessageBox.Show("除数不能为0");
            }
            //返回计算结果
            return result;
        }

        /// <summary>
        /// 点击"+,-,×,÷"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //判断输入项的最后以为是否是.
            if (txtResult.Text.Substring(txtResult.Text.Length - 1) == btnDian.Text)
            {
                //如果是删除点
                txtResult.Text = txtResult.Text.Substring(0, txtResult.Text.Length - 1);
            }

            Button thisBtn = sender as Button;

            //判断计算项是否不为空并且不包含“=”
            //列1：           列2（计算项为空） 列3（计算结果不为空 但包含“=”）
            //计算项1：123+       计算项2：     计算项3：123=
            //输入项1：2          输入项2：2    输入项3：2
            if (txtAlgorithm.Text != "" && !txtAlgorithm.Text.Contains("="))
            {
                //计算项不为空并且不包含“=” 进行计算
                decimal result = Result();
                //将输入项改为计算结果
                txtResult.Text = result.ToString();

                //此时计算项1：123+
                //此时输入项1：125
            }

            //将计算项改为计算结果并添加“+ - * /”对应符号
            txtAlgorithm.Text = txtResult.Text + thisBtn.Text;
            //结果：
            //最后计算项1：125+  计算项2：2+  计算项3：2+  
            //最后输入项1：125   输入项2：2   输入项4：2

            index = 1;
        }

        /// <summary>
        /// 点击"="
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnResult_Click(object sender, EventArgs e)
        {
            #region 点击“=” 与“.”的操作

            //判断输入项最后以是否为“.”
            //列：
            //计算项：
            //输入项： 123.
            if (txtResult.Text.Substring(txtResult.Text.Length - 1) == btnDian.Text)
            {
                //将点删除
                txtResult.Text = txtResult.Text.Substring(0, txtResult.Text.Length - 1);
                //结果：
                //计算项：123
                //输入项：123
            } 
            #endregion

            //判断计算项最后以为是否不包含“=” 并且计算项不为空
            //列：
            //计算项： 123+
            //输入项   2
            if (txtAlgorithm.Text != "" && !txtAlgorithm.Text.Contains("="))
            {
                //计算结果
                decimal result = Result();
                txtAlgorithm.Text += txtResult.Text + "=";
                txtResult.Text = result.ToString();
                //结果：
                //计算项：123+2=
                //输入项：125

                //此时下一次点击数字 清空输入项与计算项
                index = 2;
                
            }

            //列（计算项为空）：    列2（计算项不为空 但包含=）
            //计算项：              计算项2： 123=
            //输入项： 123          输入项2： 2
            else
            {
                txtAlgorithm.Text = txtResult.Text;
                txtAlgorithm.Text += "=";
                index = 1;
                //结果：
                //计算项：123=      计算项2： 2=
                //输入项：123       输入项2： 2
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //MessageBox.Show((0.1+0.2).ToString());
        }

        /// <summary>
        /// 正负号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnZhengFu_Click(object sender, EventArgs e)
        {
            //判断输入项是否大于0
            if (Convert.ToDecimal(txtResult.Text) > 0)
            {
                //添加负号
                txtResult.Text = "-" + txtResult.Text;
            }
            else if (Convert.ToDecimal(txtResult.Text) < 0)
            {
                //删除负号
                txtResult.Text = txtResult.Text.Substring(1);
            }
        }

        /// <summary>
        /// 点击“←”退格键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnYu_Click(object sender, EventArgs e)
        {
            //如果输入项为0 不退格
            if (txtResult.Text=="0")
            {
                return;
            }
            //如果输入项为1位数 改为0
            else if (txtResult.Text.Length==1)
            {
                txtResult.Text = "0";
            }
            //否则去除输入项最后一位数
            else
            {
                txtResult.Text= txtResult.Text.Substring(0, txtResult.Text.Length - 1);
            }
        }
    }
}