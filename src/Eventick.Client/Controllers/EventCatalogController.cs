﻿using System;
using System.Threading.Tasks;
using Eventick.Web.Extensions;
using Eventick.Web.Models;
using Eventick.Web.Models.Api;
using Eventick.Web.Models.View;
using Eventick.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace Eventick.Web.Controllers
{
    public class EventCatalogController : Controller
    {
        private readonly IEventCatalogService eventCatalogService;
        private readonly IShoppingBasketService shoppingBasketService;
        private readonly Settings settings;

        public EventCatalogController(IEventCatalogService eventCatalogService, IShoppingBasketService shoppingBasketService, Settings settings)
        {
            this.eventCatalogService = eventCatalogService;
            this.shoppingBasketService = shoppingBasketService;
            this.settings = settings;
        }

        public async Task<IActionResult> Index(Guid categoryId)
        {
            var currentBasketId = Request.Cookies.GetCurrentBasketId(settings);

            var getBasket = currentBasketId == Guid.Empty ? Task.FromResult<Basket>(null) :
                shoppingBasketService.GetBasket(currentBasketId);

            var getCategories = eventCatalogService.GetCategories();

            var getEvents = categoryId == Guid.Empty ? eventCatalogService.GetAll() :
                eventCatalogService.GetByCategoryId(categoryId);

            await Task.WhenAll(new Task[] { getBasket, getCategories, getEvents });

            var numberOfItems = getBasket.Result?.NumberOfItems ?? 0;

            return View(
                new EventListModel
                {
                    Events = getEvents.Result,
                    Categories = getCategories.Result,
                    NumberOfItems = numberOfItems,
                    SelectedCategory = categoryId
                }
            );
        }

        [HttpPost]
        public IActionResult SelectCategory([FromForm]Guid selectedCategory)
        {
            return RedirectToAction("Index", new { categoryId = selectedCategory });
        }

        public async Task<IActionResult> Detail(Guid eventId)
        {
            var ev = await eventCatalogService.GetEvent(eventId);
            return View(ev);
        }
    }
}
