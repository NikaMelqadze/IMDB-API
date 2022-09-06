using IMDB.Core.Applications.Common.Interfaces;
using System;
using System.Linq;

namespace IMDB.Core.Applications.Common.Jobs
{
    public class OfferJob : IOfferJob
    {
        private IUnitOfWork _uow;
        private IDateTimeService _dateTime;
        private IMailSender _mailSender;
        public OfferJob(IUnitOfWork uow, IDateTimeService dateTime, IMailSender mailSender)
        {
            _uow = uow;
            _dateTime = dateTime;
            _mailSender = mailSender;
        }

        public void OfferMovies()
        {
            var startOffMonth = new DateTime(_dateTime.Now.Year, _dateTime.Now.Month, 1);

            var wachList = _uow.WatchListsRepo.GetIenumarableWatchList();

            var itemsToOffer = (from w in wachList
                                group w by w.UserId into gr
                                where gr.Count(g => !g.Watched) > 3 &&
                                      gr.Any(g => !g.Watched && !g.OfferHistories.Any(of => of.OfferDate > startOffMonth))
                                select gr.Where(g => !g.Watched && !g.OfferHistories.Any(of => of.OfferDate > startOffMonth))
                                .OrderByDescending(g => g.FilmRating).FirstOrDefault()).ToList();

            foreach (var itemToOffer in itemsToOffer)
            {
                try
                {
                    string mailBody = string.Format("<table width='100%' border='0' cellspacing='0' cellpadding='20' background='{0}'><tr><td><p>{1}({2}) <br> {3}  </p></td></tr></table>", itemToOffer.FilmPoster, itemToOffer.FilmTitle, itemToOffer.FilmRating, itemToOffer.FilmDescription);

                    _mailSender.Send("Offer", mailBody);

                    _uow.OfferHistoriesRepo.AddEntityItem(new Domains.Entities.OfferHistory
                    {
                        OfferDate = DateTime.Now,
                        WatchListId = itemToOffer.Id
                    });

                    _uow.SaveChanges();
                }
                catch
                {
                    //log Exceptions
                }
            }
        }
    }
}
