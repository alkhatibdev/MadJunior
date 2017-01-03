using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace MadJunior
{
    [Activity(Label = "Board", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class Board : Activity
    {
        private TextView tvSecond;
        private TextView tvTask;
        private TextView tvFinalReview;
        private TextView tvPoints;

        private Button btnOption1;
        private Button btnOption2;
        private Button btnOption3;
        private Button btnOption4;

        private SeekBar seekBar;

        private string answer = "";
        private int heard = 1;
        private static int solveTime = 10;
        private int second = solveTime;
        private bool isFinsh = false;
        private int counter = 0;
        private int down = 5;
        private int TaskSize = 0;
        private int points = 0;

        private Timer timer;
        private Timer downTimer;
        private List<Question> task;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Remove ActionBar Title
            Window.RequestFeature(WindowFeatures.NoTitle);
            // Set view from the "Board" layout resource
            SetContentView(Resource.Layout.Board);

            tvSecond = FindViewById<TextView>(Resource.Id.tvSecond);
            tvTask = FindViewById<TextView>(Resource.Id.tvTask);
            tvFinalReview = FindViewById<TextView>(Resource.Id.tvFinalReview);
            tvPoints = FindViewById<TextView>(Resource.Id.tvPoints);
            seekBar = FindViewById<SeekBar>(Resource.Id.seekBar);

            btnOption1 = FindViewById<Button>(Resource.Id.btnOption1);
            btnOption2 = FindViewById<Button>(Resource.Id.btnOption2);
            btnOption3 = FindViewById<Button>(Resource.Id.btnOption3);
            btnOption4 = FindViewById<Button>(Resource.Id.btnOption4);

            // Initilize SeekBar
            seekBar.Max = solveTime;
            seekBar.Progress = solveTime;
            seekBar.Enabled = false;

            // Down Timer 
            downTimer = new Timer();
            downTimer.Interval = 1000;
            downTimer.Elapsed += DownTimer_Elapsed;

            // Timer
            timer = new Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;

            // List of Questions
            task = new Data().tasksEasy();
            task.AddRange(new Data().tasksMedium());
            task.AddRange(new Data().tasksHard());

            TaskSize = task.Count;  // Initialize Number of Tasks


            // Initilize The Clock And Options
            tvSecond.Text = "00";

            // Initilize Down Counter Message
            tvTask.Text = "≈” ⁄œ !";

            // Show Ready Counter ( 3 - 2 - 1 - GO )
            downTimer.Start();

            // Option 1
            btnOption1.Click += delegate
            {
                checkAnswer(1);
            };
            // Option 2
            btnOption2.Click += delegate
            {
                checkAnswer(2);
            };
            // Option 3
            btnOption3.Click += delegate
            {
                checkAnswer(3);
            };
            // Option 4
            btnOption4.Click += delegate
            {
                checkAnswer(4);
            };

        }

        // Down Timer Elapsed
        private void DownTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            RunOnUiThread(() => {
                tvTask.Text = down.ToString();
                if(down <= 0) {
                    tvTask.Text = "«‰ÿ·ﬁ !";
                }
                if(down < -1) {
                    // Stop Down Timer
                    downTimer.Stop();

                    // Initilize Task
                    addtask();

                    // Start Task's Timer
                    timer.Start();
                }
            });
            down--;
        }        

        // Task's Timer Elapsed  
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            processTime();
            RunOnUiThread(() =>
            {
                tvSecond.Text = (second > 9) ? second.ToString() : "0" + second;
            });
        }

        private void addtask() {
            if (counter < TaskSize)
            {
                RunOnUiThread(() =>
                {
                    Question item = task[counter];
                    tvTask.Text = item.Task;
                    answer = item.Answer;
                    btnOption1.Text = item.Option1;
                    btnOption2.Text = item.Option2;
                    btnOption3.Text = item.Option3;
                    btnOption4.Text = item.Option4;
                    counter++;
                });
            }else {
                isEnd(3);
            }
        }

        // processing the Seconds
        private void processTime()
        {
            if (second <= 0)
            {
                timer.Stop();
                isEnd(1);
            }
            else
            {
                second--;
                seekBar.Progress--;
            }
        }

        // Finish the game and reset 
        private void isEnd(int type) {
            RunOnUiThread(() =>
            {   if (type == 1)
                {
                    tvFinalReview.Text = tvTask.Text;
                    tvTask.Text = "≈‰ ÂÏ «·Êﬁ ";
                    counter = 0;
                    timer.Stop();
                    btnOption1.Enabled = false;
                    btnOption2.Enabled = false;
                    btnOption3.Enabled = false;
                    btnOption4.Enabled = false;
                    isFinsh = true;
                    printAnswer();
                }else if(type == 2) {
                    if(heard <= 0) {
                        tvFinalReview.Text = tvTask.Text;
                        tvTask.Text = "≈‰ Â  «··⁄»…";
                        //points =  // points
                        tvPoints.Text = points + " ‰ﬁÿ… + "+second;
                        points += second; // total points
                        counter = 0;
                        timer.Stop();
                        btnOption1.Enabled = false;
                        btnOption2.Enabled = false;
                        btnOption3.Enabled = false;
                        btnOption4.Enabled = false;
                        isFinsh = true;
                        printAnswer();
                    }
                } else if(type == 3) {
                    tvFinalReview.Text = "·ﬁœ √ﬂ„·  "+ TaskSize + "  ÕœÌ° √‰  „«Â—";
                    tvTask.Text = " Â«‰Ì‰«° ·ﬁœ ›“  :)";
                    points += solveTime; // points
                    tvPoints.Text = points + " ‰ﬁÿ… + " + second;
                    points += second; // total points
                    counter = 0;
                    timer.Stop();
                    btnOption1.Enabled = false;
                    btnOption2.Enabled = false;
                    btnOption3.Enabled = false;
                    btnOption4.Enabled = false;
                    isFinsh = true;
                }
            });
        }

        private void printAnswer()
        {
            if(btnOption1.Text == answer) {
                btnOption1.SetBackgroundColor(Android.Graphics.Color.Green);
            }else if(btnOption2.Text == answer) {
                btnOption2.SetBackgroundColor(Android.Graphics.Color.Green);
            }
            else if(btnOption3.Text == answer) {
                btnOption3.SetBackgroundColor(Android.Graphics.Color.Green);
            }
            else if(btnOption4.Text == answer) {
                btnOption4.SetBackgroundColor(Android.Graphics.Color.Green);
            }
        }

        // Check the Answer when user choose an option
        private void checkAnswer(int option)
        {
            switch (option)
            {
                case 1:
                    if (btnOption1.Text.Equals(answer))
                    {
                        if (counter < TaskSize)
                        {
                            addtask();
                            second += solveTime;
                            seekBar.Max = second;
                            seekBar.Progress = second;
                            points += solveTime; // earning points
                            tvPoints.Text = points + " ‰ﬁÿ…";
                        }else {
                            isEnd(3);
                        }
                    }
                    else
                    {
                        heard--;
                        isEnd(2);
                    }
                    break;
                case 2:
                    if (btnOption2.Text.Equals(answer))
                    {
                        if (counter < TaskSize)
                        {
                            addtask();
                            second += solveTime;
                            seekBar.Max = second;
                            seekBar.Progress = second;
                            points += solveTime; // earning points
                            tvPoints.Text = points + " ‰ﬁÿ…";
                        }
                        else
                        {
                            isEnd(3);
                        }
                    }
                    else
                    {
                        heard--;
                        isEnd(2);
                    }
                    break;
                case 3:
                    if (btnOption3.Text.Equals(answer))
                    {
                        if (counter < TaskSize)
                        {
                            addtask();
                            second += solveTime;
                            seekBar.Max = second;
                            seekBar.Progress = second;
                            points += solveTime; // earning points
                            tvPoints.Text = points + " ‰ﬁÿ…";
                        }
                        else
                        {
                            isEnd(3);
                        }
                    }
                    else
                    {
                        heard--;
                        isEnd(2);
                    }
                    break;
                case 4:
                    if (btnOption4.Text.Equals(answer))
                    {
                        if (counter < TaskSize)
                        {
                            addtask();
                            second += solveTime;
                            seekBar.Max = second;
                            seekBar.Progress = second;
                            points += solveTime; // earning points
                            tvPoints.Text = points + " ‰ﬁÿ…";
                        }
                        else
                        {
                            isEnd(3);
                        }
                    }
                    else
                    {
                        heard--;
                        isEnd(2);
                    }
                    break;
            }
        }

        // Return a User to "Home" When Press Back
        public override void OnBackPressed()
        {
            // Stop the Timer First
            timer.Stop();

            if (!isFinsh)
            {
                // Show a Alert Dialog
                var alert = new AlertDialog.Builder(this);
                alert.SetTitle("Â·  Êœ ≈‰Â«¡ «· ÕœÌ!");
                alert.SetPositiveButton("≈‰Â«¡", delegate
                {
                    Intent intent = new Intent(this, typeof(Home));
                    second = 0;
                    StartActivity(intent);
                    Finish();
                });
                alert.SetNegativeButton("Ê«’· «· ÕœÌ", delegate
                {
                    timer.Start();
                });
                alert.Create();
                alert.Show();
            } else {
                Intent intent = new Intent(this, typeof(Home));
                second = 0;
                StartActivity(intent);
                Finish();
            }
        }

        // Inner Class for Questions Strcture
        public class Question
        {
            public string Task { get; set; }
            public string Option1 { get; set; }
            public string Option2 { get; set; }
            public string Option3 { get; set; }
            public string Option4 { get; set; }
            public string Answer { get; set; }
            public string Level { get; set; }

            public Question(string task, string op1, string op2, string op3, string op4, string ans, string lvl) {
                Task = task;
                Option1 = op1;
                Option2 = op2;
                Option3 = op3;
                Option4 = op4;
                Answer = ans;
                Level = lvl;

            }
        }

    }
}