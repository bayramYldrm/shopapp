using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using shopapp.business.Abstract;
using shopapp.entity;
using shopapp.webui.Extensions;
using shopapp.webui.Models;

namespace shopapp.webui.Controllers
{
    public class ShopController:Controller
    {
        private IProductService _productService;
        private ICommentService _commentService;

        public ShopController(IProductService productService, ICommentService commentService)
        {
            this._productService=productService;
            this._commentService=commentService;
        }

        // localhost/products/telefon?page=1
        public IActionResult List(string category,int page=1)
        {
            const int pageSize=6;
            var productViewModel = new ProductListViewModel()
            {
                PageInfo = new PageInfo()
                {
                    TotalItems = _productService.GetCountByCategory(category),
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    CurrentCategory = category
                },
                Products = _productService.GetProductsByCategory(category,page,pageSize)
            };

            return View(productViewModel);
        }

        public IActionResult Details(string url)
        {
            if (url == null)
            {
                return NotFound();
            }

            Product product = _productService.GetProductDetails(url);

            if (product == null)
            {
                return NotFound();
            }

            // Ürün ID'sine göre ilgili comment verilerini alın
            var comments = _commentService.GetCommentsByProductId(product.ProductId);

            // Yeni özelliklerin değerlerini hesaplayın
            int totalComments = comments.Count;
            double averageVotePoint = comments.Any() ? comments.Average(c => c.VotePoint) : 0;
        
            // Yorumları ProductDetailModel'e ekleyin
            var model = new ProductDetailModel
            {
                Product = product,
                Categories = product.ProductCategories.Select(i => i.Category).ToList(),
                Comments = comments,
                TotalComments = totalComments,
                AverageVotePoint = averageVotePoint
            };

    return View(model);
        }

        public IActionResult Search(string q)
        {
            var productViewModel = new ProductListViewModel()
            {
                Products = _productService.GetSearchResult(q)
            };

            return View(productViewModel);
        }

        public IActionResult CommentCreate()
        {
            // Yorum eklemek için giriş yapmış bir kullanıcı mı kontrol edin
            if (!User.Identity.IsAuthenticated)
            {
                // Kullanıcı giriş yapmadıysa, giriş yapmalarını sağlayan bir sayfaya yönlendirin
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        [HttpPost]
        public IActionResult CommentCreate(CommentModel model)
        {
            // Yorum eklemek için giriş yapmış bir kullanıcı mı kontrol edin
            if (!User.Identity.IsAuthenticated)
            {
                // Kullanıcı giriş yapmadıysa, giriş yapmalarını sağlayan bir sayfaya yönlendirin
                return RedirectToAction("Login", "Account");
            }

            // ModelState.IsValid özelliğini kontrol edin, gelen model doğrulama kurallarını karşılıyor mu
            if (ModelState.IsValid)
            {
                // Yorumun entity modelini oluşturun
                var entity = new Comment()
                {
                    CommentId = model.CommentId,
                    VotePoint = model.VotePoint,
                    CommentIcon = model.CommentIcon,
                    ProductId = model.ProductId,
                    CommentText = model.CommentText,
                    CommentDate = DateTime.Now, // Yorumun tarihini şu anki zamana ayarlayın
                    UserName = User.Identity.Name // Yorumu yapan kullanıcının kimliğini alın
                };

                // Comment servisini kullanarak yeni yorumu oluşturun
                _commentService.Create(entity);

                // Başarılı bir şekilde yorum eklendiğine dair bir mesaj oluşturun
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Comment added.",
                    Message = "Your comment has been successfully added.",
                    AlertType = "success"
                });

                // Yorum eklendikten sonra ana sayfaya yönlendirin
                return RedirectToAction("Index", "Home");
            }
            else{
                TempData.Put("message", new AlertMessage()
                {
                    Title = "Comment could not be added.",
                    Message = "Your attempt to add a comment was unsuccessful.",
                    AlertType = "danger"
                });
                return RedirectToAction("Index","Home");
            }
        }

          public IActionResult ListComments(int id)
          {
              // Ürün ID'sine göre ilgili comment verilerini alın
              var comments = _commentService.GetCommentsByProductId(id);

              // CommentListViewModel'e verileri aktarın
              var viewModel = new CommentListViewModel
              {
                  ProductId = id,
                  Comments = comments
              };

              // Comment verilerini içeren view'i gösterin
              return View(viewModel);
          }
    }
}