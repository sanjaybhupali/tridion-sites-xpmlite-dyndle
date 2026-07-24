using DD4T.ContentModel;
using DD4T.ContentModel.Contracts.Configuration;
using DD4T.ContentModel.Contracts.Logging;
using DD4T.ContentModel.Factories;
using DD4T.Core.Contracts.ViewModels;
using DD4T.Mvc.Controllers;
using DyndleWebApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DyndleWebApp.Controllers
{
    public class TeaserCollectionController1 : TridionControllerBase
    {
        private readonly IComponentFactory _componentFactory;
        private readonly IViewModelFactory _viewModelFactory;

        public TeaserCollectionController1(
            IPageFactory pageFactory,
            IComponentPresentationFactory componentPresentationFactory,
            ILogger logger,
            IDD4TConfiguration configuration,
            IComponentFactory componentFactory,
            IViewModelFactory viewModelFactory)
            : base(pageFactory, componentPresentationFactory, logger, configuration)
        {
            _componentFactory = componentFactory;
            _viewModelFactory = viewModelFactory;
        }

        [ChildActionOnly]
        public ActionResult TeaserCollection(IComponentPresentation componentPresentation)
        {
            // Build the TeaserCollection entity model from the component presentation
            var model = _viewModelFactory.BuildViewModel(componentPresentation) as TeaserCollection;

            var viewModel = new TeaserCollectionViewModel();

            if (model?.teasers != null)
            {
                foreach (var linkedComponent in model.teasers)
                {
                    IComponent component;
                    _componentFactory.TryGetComponent(linkedComponent.Id, out component);

                    if (component != null)
                    {
                        var teaser = _viewModelFactory.BuildViewModel(component) as Teaser;
                        if (teaser != null)
                            viewModel.Teasers.Add(teaser);
                    }
                }
            }

            return View(viewModel);
        }
    }
}