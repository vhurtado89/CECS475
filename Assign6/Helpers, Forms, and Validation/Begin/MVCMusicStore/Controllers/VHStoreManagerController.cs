﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers
{
    public class VHStoreManagerController : Controller
    {
        private MusicStoreEntities db = new MusicStoreEntities();

        //
        // GET: /VHStoreManager/

        public ActionResult Index()
        {
            var albums = this.db.Albums.Include(a => a.Genre).Include(a => a.Artist).OrderBy(a => a.Price);

            return this.View(albums.ToList());
        }

        //
        // GET: /VHStoreManager/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /VHStoreManager/Create

        public ActionResult Create()
        {
            this.ViewBag.GenreId = new SelectList(this.db.Genres, "GenreId", "Name");
            this.ViewBag.ArtistId = new SelectList(this.db.Artists, "ArtistId", "Name");

            return this.View();
        }

        //
        // POST: /VHStoreManager/Create

        [HttpPost]
        public ActionResult Create(Album album)
        {
            if (ModelState.IsValid)
            {
                this.db.Albums.Add(album);
                this.db.SaveChanges();

                return this.RedirectToAction("Index");
            }

            this.ViewBag.GenreId = new SelectList(this.db.Genres, "GenreId", "Name", album.GenreId);
            this.ViewBag.ArtistId = new SelectList(this.db.Artists, "ArtistId", "Name", album.ArtistId);

            return this.View(album);
        }

        //
        // GET: /VHStoreManager/Edit/5

        public ActionResult Edit(int id)
        {
            Album album = this.db.Albums.Find(id);

            if (album == null)
            {
                return this.HttpNotFound();
            }

            this.ViewBag.GenreId = new SelectList(this.db.Genres, "GenreId", "Name", album.GenreId);
            this.ViewBag.ArtistId = new SelectList(this.db.Artists, "ArtistId", "Name", album.ArtistId);

            return this.View(album);
        }

        //
        // POST: /VHStoreManager/Edit/5

        [HttpPost]
        public ActionResult Edit(Album album)
        {
            if (ModelState.IsValid)
            {
                this.db.Entry(album).State = EntityState.Modified;
                this.db.SaveChanges();

                return this.RedirectToAction("Index");
            }

            this.ViewBag.GenreId = new SelectList(this.db.Genres, "GenreId", "Name", album.GenreId);
            this.ViewBag.ArtistId = new SelectList(this.db.Artists, "ArtistId", "Name", album.ArtistId);

            return this.View(album);
        }

        //
        // GET: /VHStoreManager/Delete/5

        public ActionResult Delete(int id)
        {
            Album album = this.db.Albums.Find(id);

            if (album == null)
            {
                return this.HttpNotFound();
            }

            return this.View(album);
        }

        //
        // POST: /VHStoreManager/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            Album album = this.db.Albums.Find(id);
            this.db.Albums.Remove(album);
            this.db.SaveChanges();

            return this.RedirectToAction("Index");
        }
    }
}
