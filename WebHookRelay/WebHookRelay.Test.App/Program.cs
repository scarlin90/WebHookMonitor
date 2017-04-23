using Octokit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebHookRelay.Test.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t = MainAsync(args);
            t.Wait();
            Console.ReadLine();
        }

        static async Task MainAsync(string[] args)
        {
            var client = new GitHubClient(new ProductHeaderValue("GitHubClient"));

            // NOTE: not real credentials
            var basicAuth = new Octokit.Credentials("MyGitHubLogin", "MyGitHubPassword"); 
            
            client.Credentials = basicAuth;

            //////////////////////////////////////////////
            //
            //  Git Hub Users Api
            //
            //////////////////////////////////////////////

            var user = await client.User.Get("scarlin90");

            Console.WriteLine("GitHub Users API");
            PrintPropertyAndValue(nameof(user.AvatarUrl), user.AvatarUrl);
            PrintPropertyAndValue(nameof(user.Bio), user.Bio);
            PrintPropertyAndValue(nameof(user.Blog), user.Blog);
            PrintPropertyAndValue(nameof(user.Collaborators), user.Collaborators);
            PrintPropertyAndValue(nameof(user.Company), user.Company);
            PrintPropertyAndValue(nameof(user.CreatedAt), user.CreatedAt);
            PrintPropertyAndValue(nameof(user.DiskUsage), user.DiskUsage);
            PrintPropertyAndValue(nameof(user.Email), user.Email);
            PrintPropertyAndValue(nameof(user.Followers), user.Followers);
            PrintPropertyAndValue(nameof(user.Following), user.Following);
            PrintPropertyAndValue(nameof(user.Hireable), user.Hireable);
            PrintPropertyAndValue(nameof(user.HtmlUrl), user.HtmlUrl);
            PrintPropertyAndValue(nameof(user.Id), user.Id);
            PrintPropertyAndValue(nameof(user.LdapDistinguishedName), user.LdapDistinguishedName);
            PrintPropertyAndValue(nameof(user.Location), user.Location);
            PrintPropertyAndValue(nameof(user.Login), user.Login);
            PrintPropertyAndValue(nameof(user.Name), user.Name);
            PrintPropertyAndValue(nameof(user.OwnedPrivateRepos), user.OwnedPrivateRepos);
            PrintPropertyAndValue(nameof(user.Permissions), user.Permissions);
            PrintPropertyAndValue(nameof(user.Plan), user.Plan);
            PrintPropertyAndValue(nameof(user.PrivateGists), user.PrivateGists);
            PrintPropertyAndValue(nameof(user.PublicGists), user.PublicGists);
            PrintPropertyAndValue(nameof(user.PublicRepos), user.PublicRepos);
            PrintPropertyAndValue(nameof(user.SiteAdmin), user.SiteAdmin);
            PrintPropertyAndValue(nameof(user.Suspended), user.Suspended);
            PrintPropertyAndValue(nameof(user.SuspendedAt), user.SuspendedAt);
            PrintPropertyAndValue(nameof(user.TotalPrivateRepos), user.TotalPrivateRepos);
            PrintPropertyAndValue(nameof(user.Type), user.Type);
            PrintPropertyAndValue(nameof(user.Url), user.Url);


            //////////////////////////////////////////////
            //
            //  Git Hub Issues Api
            //
            //////////////////////////////////////////////

            var issues = await client.Issue.GetAllForCurrent();


            foreach (var issue in issues)
            {
                PrintPropertyAndValue(nameof(issue.Title), issue.Title);
            }

            //try
            //{
            //    var iss = await client.Issue.Create("scarlin90", "WebHookMonitor", new NewIssue("Automated Issue"));
            //}
            //catch(Exception ex)
            //{
            //    await client.Issue.Update("scarlin90", "WebHookMonitor", 2, new IssueUpdate
            //    {
            //        State = ItemState.Closed
            //    });
            //}

        }

        public static void PrintPropertyAndValue(string propertyName, object propertyValue)
        {
            Console.WriteLine(string.Format("{0} - {1}", propertyName, propertyValue));
        }
        
    }
}
