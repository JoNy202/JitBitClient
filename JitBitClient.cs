using JitBitAPIClient.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace JitBitAPIClient
{
    public class JitBitClient: APIClient
    {
        public JitBitClient(string url, string userName, string userPassword) :
            base(url, userName, userPassword)
        {
        }

        // POST https://[helpdesk-url]/api/CreateUser
        // Creates a new user. Requires “helpdesk-administrator” permissions.
        public async Task<int> CreateUser(
            string username,
            string password,
            string email,
            string firstName,
            string lastName,
            string phone,
            string location,
            string company,
            string department,
            bool sendWelcomeEmail)
        {
            var content = new MultipartFormDataContent
            {
                { new StringContent(username), "username" },
                { new StringContent(password), "password" },
                { new StringContent(email), "email" },
                { new StringContent(firstName), "firstName" },
                { new StringContent(lastName), "lastName" },
                { new StringContent(phone), "phone" },
                { new StringContent(location), "location" },
                { new StringContent(company), "company" },
                { new StringContent(department), "department" }
            };

            if (sendWelcomeEmail)
            {
                content.Add(new StringContent("true"), "sendWelcomeEmail");
            }

            return await PostData<int>("CreateUser", content);
        }

        // GET https://[helpdesk-url]/api/Subscribers
        // Returns list of subscribers from a ticket
        public async Task<IEnumerable<SubscriberModel>> Subscribers(int ticketId)
        {
            return await GetData<IEnumerable<SubscriberModel>>($"Subscribers/{ticketId}");
        }

        // GET https://[helpdesk-url]/api/comments
        // Gets comments of a specified ticket.
        public async Task<IEnumerable<CommentModel>> Comments(int ticketId)
        {
            return await GetData<IEnumerable<CommentModel>>($"comments/{ticketId}");
        }

        // GET https://[helpdesk-url]/api/UserByUsername?username=admin
        // Gets all information about a user. Requires “administrator” or “technician” permissions.
        public async Task<UserModel> UserByUsername(string username)
        {
            return await GetData<UserModel>($"UserByUsername?username={username}");
        }

        // GET https://[helpdesk-url]/api/ticketGets details of a ticket. The method returns a ticket JSON object
        // Gets details of a ticket. The method returns a ticket JSON object        
        public async Task<TicketModel> Ticket(int ticketId)
        {
            return await GetData<TicketModel>($"ticket/{ticketId}");
        }

        // POST https://[helpdesk-url]/api/ticketCreates a new ticket
        // Creates a new ticket
        public async Task<int> Ticket(
            int categoryId,
            string body,
            string subject,
            int priorityId = 0,
            string tags = null,
            int userId = 0)
        {
            var content = new MultipartFormDataContent
            {
                { new StringContent(categoryId.ToString()), "categoryId" },
                { new StringContent(body), "body" },
                { new StringContent(subject), "subject" },
                { new StringContent(priorityId.ToString()), "priorityId" }
            };

            if (userId > 0)
            {
                content.Add(new StringContent(userId.ToString()), "userId");
            }

            if (!string.IsNullOrEmpty(tags))
            {
                content.Add(new StringContent(tags), "tags");
            }
           
            return await PostData<int>("ticket", content);
        }

        public async Task SetCustomField(
            int ticketId,
            int fieldId,
            string value)
        {
            var content = new MultipartFormDataContent
            {
                { new StringContent(ticketId.ToString()), "ticketId" },
                { new StringContent(fieldId.ToString()), "fieldId" },
                { new StringContent(value), "value" }
            };

            await Execute("SetCustomField", content);
        }

        public async Task<IEnumerable<dynamic>> Categories()
        {
            return await PostData<IEnumerable<dynamic>>("categories", null);
        }
    }
}