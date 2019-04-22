using NewLoginAapp.Base.SQLite;
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
	public partial class SignUpPage : ContentPage
	{
        public UserSQLiteService userSQLiteService = new UserSQLiteService();
        public SignUpPage ()
		{
			InitializeComponent ();
		}

        //注册
        private async void Register_Clicked(object sender, EventArgs e)
        {
            //验证

            //本地提交
            var user = new User()
            {
                Username = User_Name.Text.Trim(),
                Password = User_Pwd.Text.Trim(),
                Email = User_Email.Text.Trim()
            };
            try
            {
                var isSuccful = userSQLiteService.SaveUser(user).Result;
                if (isSuccful != 0)
                {
                    //跳转到登录界面
                    App.isUserLogIn = true;
                    Navigation.InsertPageBefore(new MainPage(), Navigation.NavigationStack.First());
                    await Navigation.PopToRootAsync();
                }
                else
                {
                    await DisplayAlert("操作提示", "注册失败", "确定");
                }
            }
            catch (Exception ex)
            {


                throw ex;
            }
           
            //Api提交


            //如果成功弹出注册页 登录界面为活跃界面
            await Navigation.PopAsync();
        }
    }
}