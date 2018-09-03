using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace TPSite.Controllers
{
    public class Live2dController : Controller
    {
        [HttpGet]
        public IActionResult GetRand()
        {
            var modelArry = new[]{
                "Animal Costume Racoon.png", "Animal Costume.png", "Bunny Girl Costume.png", "Cake Costume Choco.png",
                "Cake Costume Cream.png", "default-costume.png", "Dress Costume Brown.png", "Dress Costume.png",
                "Frill Bikini Costume Green.png", "Furisode Costume.png", "Kids Costume Navy.png", "Maid Costume Red.png",
                "Maid Costume.png", "New2015 Costume Pajamas.png", "New2015 Costume.png", "Qipao Costume Pink.png",
                "Qipao Costume Red.png", "Sailor Costume Black.png", "Sailor Costume.png", "Sakura Costume Navy.png",
                "Sakura Costume.png", "Santa Costume Green.png", "Sarori Costume.png", "Star Witch Costume Brown.png",
                "Star Witch Costume.png", "Succubus Costume Black.png", "Succubus Costume Red.png",
                "Sukumizu Costume White.png", "Sukumizu Costume.png", "Summer Dress Costume Blue.png",
                "Summer Dress Costume White.png", "Tirami1 Costume.png", "Turtleneck Costume Red.png",
                "Winter Coat Costume Pink.png", "Winter Coat Costume White.png", "Winter Costume White.png",
                "Winter Costume.png", "Witch Costume White.png", "Witch Costume.png"};
            var rand = new Random().Next(0, modelArry.Length);
            string img = modelArry[rand];
            var obj = new Rootobject();
            obj.textures = new[] { "textures/" + img };
            var json = JsonConvert.SerializeObject(obj);
            json = json.Replace("_Null", "").Replace("{0}", img);
            return Content(json);
        }
    }
    public class Rootobject
    {
        public string version { get; set; } = "1.0.0";
        public string model { get; set; } = "model.moc";
        public string[] textures { get; set; } = { "textures/{0}" };
        public Layout layout { get; set; } = new Layout();
        public Hit_Areas_Custom hit_areas_custom { get; set; } = new Hit_Areas_Custom();
        public Motions motions { get; set; } = new Motions();
    }

    public class Layout
    {
        public float center_x { get; set; } = 0.0f;
        public float center_y { get; set; } = -0.05f;
        public float width { get; set; } = 2.0f;
    }

    public class Hit_Areas_Custom
    {
        public float[] head_x { get; set; } = { -0.35f, 0.6f };
        public float[] head_y { get; set; } = { 0.19f, -0.2f };
        public float[] body_x { get; set; } = { -0.3f, -0.25f };
        public float[] body_y { get; set; } = { 0.3f, -0.9f };
    }

    public class Motions
    {
        public Idle[] idle { get; set; } =
        {
            new Idle() {file = "motions/WakeUp.mtn"}, new Idle() {file = "motions/Breath1.mtn"},
            new Idle() {file = "motions/Breath2.mtn"}, new Idle() {file = "motions/Breath3.mtn"},
            new Idle() {file = "motions/Breath5.mtn"}, new Idle() {file = "motions/Breath7.mtn"},
            new Idle() {file = "motions/Breath8.mtn"}
        };
        public Sleepy[] sleepy { get; set; } = { new Sleepy() };

        public Flick_Head[] flick_head { get; set; } =
        {
            new Flick_Head() {file = "motions/Touch Dere1.mtn"}, new Flick_Head() {file = "motions/Touch Dere2.mtn"},
            new Flick_Head() {file = "motions/Touch Dere3.mtn"}, new Flick_Head() {file = "motions/Touch Dere4.mtn"},
            new Flick_Head() {file = "motions/Touch Dere5.mtn"}, new Flick_Head() {file = "motions/Touch Dere6.mtn"}
        };

        public Tap_Body[] tap_body { get; set; } =
        {
            new Tap_Body() {file = "motions/Touch1.mtn"}, new Tap_Body() {file = "motions/Touch2.mtn"},
            new Tap_Body() {file = "motions/Touch3.mtn"}, new Tap_Body() {file = "motions/Touch4.mtn"},
            new Tap_Body() {file = "motions/Touch5.mtn"}, new Tap_Body() {file = "motions/Touch6.mtn"}
        };

        public Child[] _Null { get; set; } =
        {
            new Child(){file="motions/Breath1.mtn"},
            new Child(){file="motions/Breath2.mtn"},
            new Child(){file="motions/Breath3.mtn"},
            new Child(){file="motions/Breath4.mtn"},
            new Child(){file="motions/Breath5.mtn"},
            new Child(){file="motions/Breath6.mtn"},
            new Child(){file="motions/Breath7.mtn"},
            new Child(){file="motions/Breath8.mtn"},
            new Child(){file="motions/Fail.mtn"},
            new Child(){file="motions/Sleeping.mtn"},
            new Child(){file="motions/Success.mtn"},
            new Child(){file="motions/Sukebei1.mtn"},
            new Child(){file="motions/Sukebei2.mtn"},
            new Child(){file="motions/Sukebei3.mtn"},
            new Child(){file="motions/Touch Dere1.mtn"},
            new Child(){file="motions/Touch Dere2.mtn"},
            new Child(){file="motions/Touch Dere3.mtn"},
            new Child(){file="motions/Touch Dere4.mtn"},
            new Child(){file="motions/Touch Dere5.mtn"},
            new Child(){file="motions/Touch Dere6.mtn"},
            new Child(){file="motions/Touch1.mtn"},
            new Child(){file="motions/Touch2.mtn"},
            new Child(){file="motions/Touch3.mtn"},
            new Child(){file="motions/Touch4.mtn"},
            new Child(){file="motions/Touch5.mtn"},
            new Child(){file="motions/Touch6.mtn"},
            new Child(){file="motions/WakeUp.mtn"}
        };
    }

    public class Idle
    {
        public string file { get; set; }
    }

    public class Sleepy
    {
        public string file { get; set; } = "motions/Sleeping.mtn";
    }

    public class Flick_Head
    {
        public string file { get; set; }
    }

    public class Tap_Body
    {
        public string file { get; set; }
    }

    public class Child
    {
        public string file { get; set; }
    }
}