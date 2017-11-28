using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IBM.Books.Catalog.API.Infrastructure;
using Microsoft.EntityFrameworkCore;
using IBM.Books.Catalog.API.DomainModel;
using IBM.Books.Catalog.API.Infrastructure.Enumerations;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly CatalogContext _catalogContext;

        public ValuesController(CatalogContext context)
        {
            _catalogContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        //[HttpGet]
        //[Route("[action]")]
        //public async Task SeedDb()
        //{
        //    // Publishers

        //    if (await _catalogContext.Publishers.AnyAsync())
        //    {
        //        _catalogContext.Publishers.RemoveRange(_catalogContext.Publishers);
        //        await _catalogContext.SaveChangesAsync();
        //    }

        //    await _catalogContext.Publishers.AddAsync(new Publisher
        //    {
        //        Name = "Microsoft Press",
        //        NormalizedName = "MICROSOFT PRESS",
        //        InsertedDate = DateTime.Now,
        //        LastUpdatedDate = DateTime.Now
        //    });

        //    // Authors

        //    if (await _catalogContext.Authors.AnyAsync())
        //    {
        //        _catalogContext.Authors.RemoveRange(_catalogContext.Authors);
        //        await _catalogContext.SaveChangesAsync();
        //    }

        //    await _catalogContext.Authors.AddAsync(new Author()
        //    {
        //        FirstName = "Victor",
        //        LastName = "Isakov",
        //        InsertedDate = DateTime.Now,
        //        LastUpdatedDate = DateTime.Now,
        //        NormalizedFirstName = "VICTOR",
        //        NormalizedLastName = "ISAKOV"
        //    });

        //    await _catalogContext.Authors.AddAsync(new Author()
        //    {
        //        FirstName = "Stacia",
        //        LastName = "Varga",
        //        InsertedDate = DateTime.Now,
        //        LastUpdatedDate = DateTime.Now,
        //        NormalizedFirstName = "STACIA",
        //        NormalizedLastName = "VARGA"
        //    });

        //    await _catalogContext.Authors.AddAsync(new Author()
        //    {
        //        FirstName = "Scott",
        //        LastName = "Klein",
        //        InsertedDate = DateTime.Now,
        //        LastUpdatedDate = DateTime.Now,
        //        NormalizedFirstName = "SCOTT",
        //        NormalizedLastName = "KLEIN"
        //    });

        //    await _catalogContext.Authors.AddAsync(new Author()
        //    {
        //        FirstName = "Joseph",
        //        LastName = "D'Antoni",
        //        InsertedDate = DateTime.Now,
        //        LastUpdatedDate = DateTime.Now,
        //        NormalizedFirstName = "JOSEPH",
        //        NormalizedLastName = "D'ANTONI"
        //    });

        //    await _catalogContext.Authors.AddAsync(new Author()
        //    {
        //        FirstName = "Itzik",
        //        LastName = "Ben-Gan",
        //        InsertedDate = DateTime.Now,
        //        LastUpdatedDate = DateTime.Now,
        //        NormalizedFirstName = "ITZIK",
        //        NormalizedLastName = "BEN-GAN"
        //    });

        //    await _catalogContext.Authors.AddAsync(new Author()
        //    {
        //        FirstName = "Wouter",
        //        LastName = "De Kort",
        //        InsertedDate = DateTime.Now,
        //        LastUpdatedDate = DateTime.Now,
        //        NormalizedFirstName = "WOUTER",
        //        NormalizedLastName = "DE KORT"
        //    });

        //    await _catalogContext.Authors.AddAsync(new Author()
        //    {
        //        FirstName = "Rick",
        //        LastName = "Delorme",
        //        InsertedDate = DateTime.Now,
        //        LastUpdatedDate = DateTime.Now,
        //        NormalizedFirstName = "RICK",
        //        NormalizedLastName = "DELORME"
        //    });

        //    await _catalogContext.SaveChangesAsync();

        //    // Book references

        //    if (await _catalogContext.BookReferences.AnyAsync())
        //    {
        //        _catalogContext.BookReferences.RemoveRange(_catalogContext.BookReferences);
        //        await _catalogContext.SaveChangesAsync();
        //    }

        //    await _catalogContext.BookReferences.AddAsync(new BookReference
        //    {
        //        Title = "Exam Ref 70-764 Administering a SQL Database Infrastructure",
        //        NormalizedTitle = "EXAM REF 70-764 ADMINISTERING A SQL DATABASE INFRASTRUCTURE",
        //        ISBN = 9781509303830,
        //        PageCount = 416,
        //        Description = "Prepare for Microsoft Exam 70-764—and help demonstrate your real-world mastery of skills for database administration. This exam is intended for database administrators charged with installation, maintenance, and configuration tasks. Their responsibilities also include setting up database systems, making sure those systems operate efficiently, and regularly storing, backing up, and securing data from unauthorized access.",
        //        Language = "en",
        //        PrintedPageCount = 416,
        //        Source = (int)BookReferenceSources.Mock,
        //        PublisherId = await _catalogContext.Publishers.Where(x => x.NormalizedName == "MICROSOFT PRESS").Select(x => x.Id).SingleAsync(),
        //        Image = "Exam-Ref-70-764-Administering-a-SQL-Database-Infrastructure-Microsoft-Press.jpg",
        //        InsertedDate = DateTime.Now,
        //        LastUpdatedDate = DateTime.Now,
        //        PublishedDate = new DateTime(2017, 9, 18)
        //    });

        //    await _catalogContext.BookReferences.AddAsync(new BookReference
        //    {
        //        Title = "Exam Ref 70-768 Developing SQL Data Models with Practice Test",
        //        NormalizedTitle = "EXAM REF 70-768 DEVELOPING SQL DATA MODELS WITH PRACTICE TEST",
        //        ISBN = 9781509305599,
        //        PageCount = 400,
        //        Description = "Prepare for Microsoft Exam 70-768—and help demonstrate your real-world mastery of Business Intelligence (BI) solutions development with SQL Server 2016 Analysis Services (SSAS), including modeling and queries. Designed for experienced IT professionals ready to advance their status, Exam Ref focuses on the critical thinking and decision-making acumen needed for success at the MCSA level.",
        //        Language = "en",
        //        PrintedPageCount = 400,
        //        Source = (int)BookReferenceSources.Mock,
        //        PublisherId = await _catalogContext.Publishers.Where(x => x.NormalizedName == "MICROSOFT PRESS").Select(x => x.Id).SingleAsync(),
        //        Image = "Exam-Ref-70-768-developing-sql-database-models-with-practice-test.jpg",
        //        InsertedDate = DateTime.Now,
        //        LastUpdatedDate = DateTime.Now,
        //        PublishedDate = new DateTime(2017, 8, 1)
        //    });

        //    await _catalogContext.BookReferences.AddAsync(new BookReference
        //    {
        //        Title = "Exam Ref 70-765 Provisioning SQL Databases",
        //        NormalizedTitle = "EXAM REF 70-765 PROVISIONING SQL DATABASES",
        //        ISBN = 9781509303878,
        //        PageCount = 352,
        //        Description = "Direct from Microsoft, this Exam Ref is the official study guide for the new Microsoft 70-765 Provisioning SQL Databases certification exam, the second of two exams required for MCSA: SQL 2016 Database Administration certification.",
        //        Language = "en",
        //        PrintedPageCount = 352,
        //        Source = (int)BookReferenceSources.Mock,
        //        PublisherId = await _catalogContext.Publishers.Where(x => x.NormalizedName == "MICROSOFT PRESS").Select(x => x.Id).SingleAsync(),
        //        Image = "Exam-Ref-70-765-provisioning-sql-databases.jpg",
        //        InsertedDate = DateTime.Now,
        //        LastUpdatedDate = DateTime.Now,
        //        PublishedDate = new DateTime(2017, 11, 22)
        //    });

        //    await _catalogContext.BookReferences.AddAsync(new BookReference
        //    {
        //        Title = "Exam Ref 70-761 Querying Data with Transact-SQL",
        //        NormalizedTitle = "EXAM REF 70-761 QUERYING DATA WITH TRANSACT-SQL",
        //        ISBN = 9781509304332,
        //        PageCount = 400,
        //        Description = "Prepare for Microsoft Exam 70-761–and help demonstrate your real-world mastery of SQL Server 2016 Transact-SQL data management, queries, and database programming. Designed for experienced IT professionals ready to advance their status, Exam Ref focuses on the critical-thinking and decision-making acumen needed for success at the MCSA level.",
        //        Language = "en",
        //        PrintedPageCount = 400,
        //        Source = (int)BookReferenceSources.Mock,
        //        PublisherId = await _catalogContext.Publishers.Where(x => x.NormalizedName == "MICROSOFT PRESS").Select(x => x.Id).SingleAsync(),
        //        Image = "Exam-Ref-70-761-querying-data-with-transact-sql.jpg",
        //        InsertedDate = DateTime.Now,
        //        LastUpdatedDate = DateTime.Now,
        //        PublishedDate = new DateTime(2017, 3, 31)
        //    });

        //    await _catalogContext.BookReferences.AddAsync(new BookReference
        //    {
        //        Title = "Exam Ref 70-483 Programming in C#",
        //        NormalizedTitle = "EXAM REF 70-483 PROGRAMMING IN CSHARP",
        //        ISBN = 9780735676824,
        //        PageCount = 384,
        //        Description = "Prepare for Microsoft Exam 70-483—and help demonstrate your real-world mastery of programming in C#. Designed for experienced software developers ready to advance their status, Exam Ref focuses on the critical-thinking and decision-making acumen needed for success at the Microsoft Specialist level.",
        //        Language = "en",
        //        PrintedPageCount = 384,
        //        Source = (int)BookReferenceSources.Mock,
        //        PublisherId = await _catalogContext.Publishers.Where(x => x.NormalizedName == "MICROSOFT PRESS").Select(x => x.Id).SingleAsync(),
        //        Image = "Exam-Ref-70-483-programming-in-csharp.jpg",
        //        InsertedDate = DateTime.Now,
        //        LastUpdatedDate = DateTime.Now,
        //        PublishedDate = new DateTime(2013, 7, 15)
        //    });

        //    await _catalogContext.BookReferences.AddAsync(new BookReference
        //    {
        //        Title = "Exam Ref 70-480 Programming in HTML5 with JavaScript and CSS3",
        //        NormalizedTitle = "Exam Ref 70-480 PROGRAMMING IN HTML5 WITH JAVASCRIPT AND CSS3",
        //        ISBN = 9780735676633,
        //        PageCount = 400,
        //        Description = "Prepare for Microsoft Exam 70-480—and help demonstrate your real-world mastery of programming with HTML5, JavaScript, and CSS3. Designed for experienced developers ready to advance their status, Exam Ref focuses on the critical-thinking and decision-making acumen needed for success at the Microsoft Specialist level.",
        //        Language = "en",
        //        PrintedPageCount = 400,
        //        Source = (int)BookReferenceSources.Mock,
        //        PublisherId = await _catalogContext.Publishers.Where(x => x.NormalizedName == "MICROSOFT PRESS").Select(x => x.Id).SingleAsync(),
        //        Image = "Exam-Ref-70-480-programming-in-html5-with-javascript-and-css3.jpg",
        //        InsertedDate = DateTime.Now,
        //        LastUpdatedDate = DateTime.Now,
        //        PublishedDate = new DateTime(2014, 8, 15)
        //    });

        //    await _catalogContext.SaveChangesAsync();

        //    //

        //    if (await _catalogContext.BookReferenceAuthors.AnyAsync())
        //    {
        //        _catalogContext.BookReferenceAuthors.RemoveRange(_catalogContext.BookReferenceAuthors);
        //        await _catalogContext.SaveChangesAsync();
        //    }

        //    await _catalogContext.BookReferenceAuthors.AddAsync(new BookReferenceAuthor
        //    {
        //        AuthorId = await _catalogContext.Authors.Where(x => x.NormalizedLastName == "ISAKOV").Select(x => x.Id).SingleAsync(),
        //        BookReferenceId = await _catalogContext.BookReferences.Where(x => x.NormalizedTitle == "EXAM REF 70-764 ADMINISTERING A SQL DATABASE INFRASTRUCTURE").Select(x => x.Id).SingleAsync()
        //    });

        //    await _catalogContext.BookReferenceAuthors.AddAsync(new BookReferenceAuthor
        //    {
        //        AuthorId = await _catalogContext.Authors.Where(x => x.NormalizedLastName == "VARGA").Select(x => x.Id).SingleAsync(),
        //        BookReferenceId = await _catalogContext.BookReferences.Where(x => x.NormalizedTitle == "EXAM REF 70-768 DEVELOPING SQL DATA MODELS WITH PRACTICE TEST").Select(x => x.Id).SingleAsync()
        //    });

        //    await _catalogContext.BookReferenceAuthors.AddAsync(new BookReferenceAuthor
        //    {
        //        AuthorId = await _catalogContext.Authors.Where(x => x.NormalizedLastName == "KLEIN").Select(x => x.Id).SingleAsync(),
        //        BookReferenceId = await _catalogContext.BookReferences.Where(x => x.NormalizedTitle == "EXAM REF 70-765 PROVISIONING SQL DATABASES").Select(x => x.Id).SingleAsync()
        //    });

        //    await _catalogContext.BookReferenceAuthors.AddAsync(new BookReferenceAuthor
        //    {
        //        AuthorId = await _catalogContext.Authors.Where(x => x.NormalizedLastName == "D'ANTONI").Select(x => x.Id).SingleAsync(),
        //        BookReferenceId = await _catalogContext.BookReferences.Where(x => x.NormalizedTitle == "EXAM REF 70-765 PROVISIONING SQL DATABASES").Select(x => x.Id).SingleAsync()
        //    });

        //    await _catalogContext.BookReferenceAuthors.AddAsync(new BookReferenceAuthor
        //    {
        //        AuthorId = await _catalogContext.Authors.Where(x => x.NormalizedLastName == "BEN-GAN").Select(x => x.Id).SingleAsync(),
        //        BookReferenceId = await _catalogContext.BookReferences.Where(x => x.NormalizedTitle == "EXAM REF 70-761 QUERYING DATA WITH TRANSACT-SQL").Select(x => x.Id).SingleAsync()
        //    });

        //    await _catalogContext.BookReferenceAuthors.AddAsync(new BookReferenceAuthor
        //    {
        //        AuthorId = await _catalogContext.Authors.Where(x => x.NormalizedLastName == "DE KORT").Select(x => x.Id).SingleAsync(),
        //        BookReferenceId = await _catalogContext.BookReferences.Where(x => x.NormalizedTitle == "EXAM REF 70-483 PROGRAMMING IN CSHARP").Select(x => x.Id).SingleAsync()
        //    });

        //    await _catalogContext.BookReferenceAuthors.AddAsync(new BookReferenceAuthor
        //    {
        //        AuthorId = await _catalogContext.Authors.Where(x => x.NormalizedLastName == "DELORME").Select(x => x.Id).SingleAsync(),
        //        BookReferenceId = await _catalogContext.BookReferences.Where(x => x.NormalizedTitle == "Exam Ref 70-480 PROGRAMMING IN HTML5 WITH JAVASCRIPT AND CSS3").Select(x => x.Id).SingleAsync()
        //    });

        //    await _catalogContext.SaveChangesAsync();
        //}
    }
}
