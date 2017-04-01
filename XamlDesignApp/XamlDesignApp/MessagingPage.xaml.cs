using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamlDesignApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MessagingPage : ContentPage
	{
        public ObservableCollection<MessageData> comments { get; set; }

		public MessagingPage ()
		{
			InitializeComponent ();
            comments = new ObservableCollection<MessageData>();
		}

        protected override void OnAppearing()
        {
            comments.Add(new MessageData
            {
                userName = "Per Olsen",
                createdAt = DateTime.Now,
                comment = "Hva er det som skjer? Skal vi ikke på tur likevel?"
            });
            comments.Add(new MessageData
            {
                userName = "Nina Pedersen",
                createdAt = DateTime.Now,
                comment = "Jeg fikk vite at det bare var en spøk. Eller?"
            });
            comments.Add(new MessageData
            {
                userName = "Trine Elg",
                createdAt = DateTime.Now,
                comment = "Nei dessverre, turen ev avlyst på grunn av innreiseforbudet. Dere får mer informasjon om dette på samlingen i morgen."
            });

            IEnumerable<MessageData> orderedComments = comments.OrderByDescending(c => c.createdAt).ToList();
            CommentList.ItemsSource = new ObservableCollection<MessageData>(orderedComments);

            base.OnAppearing();
        }

        private void CommentEditor_Completed(object sender, EventArgs e)
        {
            string newComment = ((Editor)sender).Text;
            if (newComment.Length > 0)
            {
                comments.Add(new MessageData
                {
                    userName = "John-Kenneth Helland",
                    createdAt = DateTime.Now,
                    comment = newComment
                });

                IEnumerable<MessageData> orderedComments = comments.OrderByDescending(c => c.createdAt).ToList();
                CommentList.ItemsSource = new ObservableCollection<MessageData>(orderedComments);

                ((Editor)sender).Text = "";
            }
        }

        private void CommentEntry_Completed(object sender, EventArgs e)
        {
            string newComment = ((Entry)sender).Text;
            if (newComment.Length > 0)
            {
                comments.Add(new MessageData
                {
                    userName = "John-Kenneth Helland",
                    createdAt = DateTime.Now,
                    comment = newComment
                });

                IEnumerable<MessageData> orderedComments = comments.OrderByDescending(c => c.createdAt).ToList();
                CommentList.ItemsSource = new ObservableCollection<MessageData>(orderedComments);

                ((Entry)sender).Text = "";
            }
        }

        private void CommentList_Refreshing(object sender, EventArgs e)
        {
            var list = (ListView)sender;
            Exception error = null;
            try
            {
                CommentList.ItemsSource = comments;
            }
            catch (Exception ex)
            {
                error = ex;
            }
            finally
            {
                list.EndRefresh();
            }
        }
    }
}
