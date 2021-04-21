﻿using BiblioCat.Data;
using BiblioCat.Models.TableJunctions.AuthorConvention;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BiblioCat.Services.TableJunctions
{
    public class AuthorConventionService
    {
        private readonly Guid _userId;

        public AuthorConventionService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<AuthorConventionListItem> GetAuthorConventions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.AuthorConventions
                    .Select(e =>
                    new AuthorConventionListItem
                    {
                        AuthorId = e.AuthorId,
                        LastName = e.Author.LastName,
                        FirstName = e.Author.FirstName,
                        ConventionId = e.ConventionId,
                        ConventionName = e.Convention.Name
                    });
                return query.ToArray();
            }
        }

        public bool CreateAuthorConvention(AuthorConventionCreate model)
        {
            var entity = new AuthorConvention()
            {
                AuthorId = model.AuthorId,
                ConventionId = model.ConventionId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.AuthorConventions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAuthorConvention(int authorId, int conventionId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.AuthorConventions
                    .Single(e => e.AuthorId == authorId && e.ConventionId == conventionId);

                if (entity != null)
                {
                    ctx.AuthorConventions.Remove(entity);
                    return ctx.SaveChanges() == 1;
                }

                return false;
            }
        }

        public AuthorConventionDetail GetAuthorConventionById(int authorId, int conventionId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.AuthorConventions
                    .Single(e => e.AuthorId == authorId && e.ConventionId == conventionId);

                return new AuthorConventionDetail
                {
                    AuthorId = entity.AuthorId,
                    FirstName = entity.Author.FirstName,
                    LastName = entity.Author.LastName,
                    ConventionId = entity.ConventionId,
                    ConventionName = entity.Convention.Name
                };
            }
        }

        public List<SelectListItem> AuthorOptions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Authors.Select(a =>
                    new SelectListItem
                    {
                        Text = a.LastName + ", " + a.FirstName,
                        Value = a.AuthorId.ToString()
                    });

                var authorList = query.ToList();
                var orderedAuthorList = authorList.OrderBy(e => e.Text).ToList();
                orderedAuthorList.Insert(0, new SelectListItem { Text = "--Select Author--", Value = "" });

                return orderedAuthorList;
            }
        }

        public List<SelectListItem> ConventionOptions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Conventions.Select(c =>
                    new SelectListItem
                    {
                        Text = c.Name,
                        Value = c.ConventionId.ToString()
                    });

                var conventionList = query.ToList();
                var orderedConventionList = conventionList.OrderBy(e => e.Text).ToList();
                orderedConventionList.Insert(0, new SelectListItem { Text = "--Select Convention--", Value = "" });

                return orderedConventionList;
            }
        }
    }
}