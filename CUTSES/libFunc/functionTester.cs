using System;
using System.Collections.Generic;

using Android;
using Android.Widget;
using Android.OS;

namespace CUTSES
{
	public class functionTester
	{
		libFileReading file;
		List<structQA> arreyQA;

		public functionTester ( )
		{
			
		}
		public List<structQA> loadQA ( List<Button> themes, int testID, List<int> userAnswer )
		{
			List<structQA> testArreyQA = new List<structQA>();
			if (testID == themes[0].Id) {
				int  questionCount = 5, answerCount = 4;
				for (int counter = 0; counter < questionCount; counter++) {
					testArreyQA.Add ((new structQA ()).templateStruct (counter, answerCount));
					userAnswer.Add (-1);
				}
			} else if (testID == themes[1].Id) {
				testArreyQA = file.fileLoad ("themeFirst");
			}
			return testArreyQA;
		}
		public void refreshTester ( TextView question, List<RadioButton> radioArrey, structQA QA )
		{

			question.Text = QA.question;
			for (int counter = 0; counter < radioArrey.Count; counter++) {
				radioArrey [counter].Checked = false;
				radioArrey [counter].Text = QA.answer [counter];
			}
		}
		public void saveResult ( List<RadioButton> radioArrey, List<int> answer, int testNumber )
		{
			for (int counter = 0; counter < radioArrey.Count; counter++ ) {
				if (radioArrey[counter].Checked) {
					answer [testNumber] = counter;
				}
			}
		}
		public void loadResult ( List<RadioButton> radioArrey, List<int> answer, int testNumber){
			if (answer [testNumber] >= 0) {
				radioArrey [answer[testNumber]].Checked = true;
			}
		}
		public void buttonUpdate ( Button btnNext, Button btnPrev, int qCurrent, int qCount ){
			if (qCurrent == 0) {
				btnPrev.Visibility = Android.Views.ViewStates.Invisible;
			} else {
				btnPrev.Visibility = Android.Views.ViewStates.Visible;
			}
			if (qCount == qCurrent + 1) {
				btnNext.Visibility = Android.Views.ViewStates.Invisible;
			} else {
				btnNext.Visibility = Android.Views.ViewStates.Visible;
			}
		}
	}
}

