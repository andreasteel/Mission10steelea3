using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission9steelea3.Models
{
    public class EFDonationRepository : IDonationRepository
    {
        private BookstoreContext context;

        public EFDonationRepository (BookstoreContext temp)
        {
            context = temp;
        }
        public IQueryable<Donation> Donations => context.Checkouts.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void SaveDonation(Donation donation)
        {
            context.AttachRange(donation.Lines.Select(x => x.Book));

            if (donation.CheckoutId == 0)
            {
                context.Checkouts.Add(donation);
            }

            context.SaveChanges();
        }
    }
}
