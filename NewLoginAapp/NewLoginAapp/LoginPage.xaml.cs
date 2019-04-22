using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using NewLoginAapp.Base.SQLite;

namespace NewLoginAapp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        public UserSQLiteService userSQLiteService = new UserSQLiteService(); 
		public LoginPage ()
		{
			InitializeComponent ();
		}

        //注册入口
        private async void OnTapGestureRecognizerTappedLable(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());
        }
        //登录
        private async void Login_Clicked(object sender, EventArgs e)
        {
            //验证信息

            //提交
            var user = new User
            {
                Username = user_Name.Text.Trim(),
                Password =user_Password.Text.Trim()
            };
            //本地数据库
            try
            {
              var _user=  await userSQLiteService.SelectUser(user);
                if (_user != null)
                {
                    //跳转主界面
                    App.isUserLogIn = true;
                    Navigation.InsertPageBefore(new MainPage(), this);
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("操作提示","登录失败","确定");
                }
            }
            catch (Exception ex)
            { 
                throw ex;
            }
           
            //Api


        }
    }
}