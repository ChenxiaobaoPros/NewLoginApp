using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewLoginAapp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
		}

        //注册入口
        private void OnTapGestureRecognizerTappedLable(object sender, EventArgs e)
        {

        }
        //登录
        private void Login_Clicked(object sender, EventArgs e)
        {

        }
    }
}