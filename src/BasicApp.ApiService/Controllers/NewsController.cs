using BasicApp.Models.Contexts;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using BasicApp.DTO;
using BasicApp.Models;
using System;

namespace BasicApp.ApiService.Controllers
{
    public class NewsController : ApiController
    {
        // GET api/news
        public List<NewsDto> Get()
        {
            using (var context = new BasicAppEntityContext())
            {
                var list = context.News.Select(x => new NewsDto { Id = x.Id, Title = x.Title }).ToList();
                return list;
            }
        }

        // GET api/news/5
        public NewsDetailDto Get(int id)
        {
            using (var context = new BasicAppEntityContext())
            {
                var item = context.News.Select(x => new NewsDetailDto
                {
                    Id = x.Id,
                    Title = x.Title,
                    Content = x.Content,
                    CreationDate = x.CreationDate,
                    Image = x.Image
                }).SingleOrDefault(x => x.Id == id);

                return item;
            }
        }

        // POST api/news
        public void Post(NewsDetailDto data)
        {
            using (var context = new BasicAppEntityContext())
            {
                context.News.Add(new News
                {
                    Title = data.Title,
                    Content = data.Content,
                    CreationDate = data.CreationDate,
                    Image = data.Image
                });

                context.SaveChanges();
            }
        }

        // PUT api/news/5
        public void Put(NewsDetailDto data)
        {
            using (var context = new BasicAppEntityContext())
            {
                var item = context.News.SingleOrDefault(x => x.Id == data.Id);

                item.Title = data.Title;
                item.Content = data.Content;
                item.Image = data.Image;
                item.CreationDate = data.CreationDate;

                context.Entry(item).State = System.Data.Entity.EntityState.Modified;

                context.SaveChanges();
            }
        }

        // DELETE api/news/5
        public void Delete(int id)
        {
            using (var context = new BasicAppEntityContext())
            {
                var item = context.News.SingleOrDefault(x => x.Id == id);

                context.Entry(item).State = System.Data.Entity.EntityState.Deleted;

                context.SaveChanges();
            }

        }

        [HttpGet]
        [Route("api/news/today")]
        public List<NewsDetailDto> Today()
        {
            using (var context = new BasicAppEntityContext())
            {
                var today = DateTime.Now;
                var list = context.News
                            .Where(x => x.CreationDate.Year == today.Year &&
                                    x.CreationDate.Month == today.Month &&
                                    x.CreationDate.Day == today.Day)
                            .Select(x => new NewsDetailDto
                            {
                                Id = x.Id,
                                Title = x.Title,
                                CreationDate = x.CreationDate
                            }).ToList();

                return list;
            }
        }


    }
}