using FiboInfraStructure.Entity.Payroll;
using Payroll.InfraStructure.Assembler;
using Payroll.InfraStructure.Repository;
using Payroll.InfraStructure.Service;
using Payroll.Src.Dto;
using Payroll.Src.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CItyCenterSystem.Areas.Payroll.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostRepository _postRepository;
        private readonly IPostAssembler _postAssembler;
        private readonly IPostService _postService;


        public PostController(IPostRepository postRepository, IPostAssembler postAssembler, IPostService postService)
        {
            _postAssembler = postAssembler;
            _postRepository = postRepository;
            _postService = postService;

        } 
        public async Task<IActionResult> Index(PostViewModel vm,string message,string messege)
        {
            vm.Posts = new List<Post>();
            var post = await _postRepository.GetAllPostAsync();
            vm.Posts = post;
            ViewBag.Message = message;
            ViewBag.Messege = messege;
            return View(vm);
        }
        [HttpGet()]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Create(PostDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Post post = new Post();
                    await _postService.InsertAsync(dto);
                    return RedirectToAction("Index", "Post", new { message = "Post been saved successfully." });
                }
                else
                {
                    ViewBag.Message = "Error: Invalid data !";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error: Please contact Administrator.";
            }
            return View(dto);
        }
        [HttpGet()]
        public async Task<IActionResult> Update(long? id)
        {
            if (!id.HasValue)
            {

            }
            var post = await _postRepository.GetByIdAsync(id.Value) ?? throw new Exception();
            PostDto dto = new PostDto();
            _postAssembler.copyFrom(dto, post);
            return View(dto);
        }
        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> Update(PostDto dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _postService.UpdateAsync(dto);
                    return RedirectToAction("Index", "Post", new { message = "Post been Update successfully." });
                }
                else
                {
                    ViewBag.Message = "Error: Invalid data !";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error: Please contact Administrator.";
            }
            return View();
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(long id)
        {
            var post = await _postRepository.GetByIdAsync(id) ?? throw new Exception();
            return View(post);
        }

        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public async Task<IActionResult> DeleteConfirmed(Post post)
        {
            try
            {
                if (post != null)
                {
                    await _postService.Delete(post.Id).ConfigureAwait(true);
                    return RedirectToAction("Index", "Post", new { messege = "Post been Delete successfully." });
                }
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error: Please contact Administrator.";
            }
            return View(post);
        }
    }
}
