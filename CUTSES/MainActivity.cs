using Android.App;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace CUTSES
{
	[Activity (Label = "CUTSES", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		functionTester tester = new functionTester();

		public string userName;
		public static int questionCount = 5;
		public int questionCurrent = 0;

		List<structQA> mainQA = new List<structQA>();
		List<int> userAnswer = new List<int>();
		List<RadioButton> radioArrey = new List<RadioButton>();
		List<Button> themes = new List<Button>();

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Login layout settings
			layoutLoginInit();

		}
		public  void layoutLoginInit()
		{
			SetContentView (Resource.Layout.Login);
			EditText inputLogin = FindViewById<EditText> (Resource.Id.inputName);
			EditText inputPassword = FindViewById<EditText> (Resource.Id.inputPassword);
			Button buttonAccept = FindViewById<Button> (Resource.Id.buttonAccept);

			buttonAccept.Click += delegate {
				if(inputLogin.Text != ""){
					userName = inputLogin.Text;
					layoutThemeInit();
				}
				else{

				}
			};
		}
		public void layoutThemeInit()
		{
			SetContentView (Resource.Layout.ThemePicker);
			themes.Add (FindViewById<Button> (Resource.Id.themeFirst));
			themes.Add (FindViewById<Button> (Resource.Id.themeSecond));
			foreach (Button theme in themes) {
				theme.Click += delegate {
					mainQA = tester.loadQA( themes, theme.Id, userAnswer );
					layoutTesterInit();
				};
			}
		}
		public void layoutTesterInit()
		{
			SetContentView(Resource.Layout.TestingPage);
			Button buttonNext = FindViewById<Button> (Resource.Id.buttonNext);
			Button buttonPrev = FindViewById<Button> (Resource.Id.buttonPrev);
			Button buttonFinish = FindViewById<Button> (Resource.Id.buttonFinish);
			TextView textQuestion = FindViewById<TextView> (Resource.Id.textQuestion);
			TextView questionCounter = FindViewById<TextView> (Resource.Id.textQuestionCounter);
			RadioGroup groupAnswer = FindViewById<RadioGroup> (Resource.Id.groupAnswer);

			radioArrey.Add (FindViewById<RadioButton> (Resource.Id.buttonRadioAnswer1));
			radioArrey.Add (FindViewById<RadioButton> (Resource.Id.buttonRadioAnswer2));
			radioArrey.Add (FindViewById<RadioButton> (Resource.Id.buttonRadioAnswer3));
			radioArrey.Add (FindViewById<RadioButton> (Resource.Id.buttonRadioAnswer4));

			tester.refreshTester ( textQuestion, radioArrey, mainQA[questionCurrent], groupAnswer );
			tester.questionCounterUpdate ( questionCurrent, questionCount, questionCounter);
			tester.buttonUpdate ( buttonNext, buttonPrev, questionCurrent, questionCount);
			buttonNext.Click += delegate {
				tester.saveResult( radioArrey, userAnswer, questionCurrent );
				questionCurrent++;
				tester.refreshTester ( textQuestion, radioArrey, mainQA[questionCurrent], groupAnswer );
				tester.buttonUpdate( buttonNext, buttonPrev, questionCurrent, questionCount );
				tester.questionCounterUpdate ( questionCurrent, questionCount, questionCounter);
				tester.loadResult ( radioArrey, userAnswer, questionCurrent );
			};
  			buttonPrev.Click += delegate {
				tester.saveResult( radioArrey, userAnswer, questionCurrent );
				questionCurrent--;
				tester.refreshTester ( textQuestion, radioArrey, mainQA[questionCurrent], groupAnswer );
				tester.buttonUpdate( buttonNext, buttonPrev, questionCurrent, questionCount );
				tester.questionCounterUpdate ( questionCurrent, questionCount, questionCounter);
				tester.loadResult ( radioArrey, userAnswer, questionCurrent );
			};
			buttonFinish.Click += delegate {
				SetContentView(Resource.Layout.Result);
				TextView labelAnswer = FindViewById<TextView>(Resource.Id.labelAnswer);
				labelAnswer.Text = userName;
				functionResult result = new functionResult(mainQA, userAnswer, labelAnswer);

			};
		}
	}
}


