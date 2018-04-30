namespace Group_News.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Group_News.Models;


    internal sealed class Configuration : DbMigrationsConfiguration<Group_News.Context.GroupNewsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Group_News.Context.GroupNewsContext db)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            // AUTHORS
            var Authors = new List<Author>
            {
                new Author { Name = "Chris" },
                new Author { Name = "Darlene" },
                new Author { Name = "Aaron" },
                new Author { Name = "Mark" },
                new Author { Name = "Stanley" }
            };

            // CATEGORIES
            var Categories = new List<Category>
            {
                new Category { Name = "Sports" },
                new Category { Name = "Politics" },
                new Category { Name = "Tech" },
                new Category { Name = "Food" },
                new Category { Name = "Nature" },
            };

            // STORIES
            var Stories = new List<Story>
            {
                new Story
                {
                    Headline = "Super awesome headline!!!",
                    Body = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt.",
                    CreationDate = new DateTime(1999, 08, 20),
                    CategoryID = 1,
                    AuthorID = 1
                },

                new Story
                {
                    Headline = "LIGHTNING GOES INTO GAME 3!!!",
                    Body = "Hockey ipsum dolor sit amet drop the gloves go for a skate power play, Henderson Zamboni Crosby stripes slap shot cherry picking. Cement hands Chelios Sakic forecheck icing check to the head. Hip check offside Lidström Cyclone Taylor, check to the head d-man Hašek beer league Blades of Steel goon fight strap deke. Go for a skate Hašek drop pass cherry picking.",
                    CreationDate = new DateTime(2018, 04, 30),
                    CategoryID = 1,
                    AuthorID = 2
                },
                new Story
                {
                    Headline = "Infinity war best thing since sliced bread",
                    Body = "The Avengers team like you’ve never seen them before. Earths Mightiest Heroes reunite with their biggest guns at the forefront to take on familiar enemies and new threats alike. The instructors at Avengers Academy hope to steer these super-powered and highly-troubled teens in the right direction, but twists and turns abound. Iron Man, Thor, Captain America and the rest of Earths Mightiest Heroes unite to stand against the threats none can face alone.",
                    CreationDate = new DateTime(2018, 04, 22),
                    CategoryID = 3,
                    AuthorID = 3
                },
                new Story
                {
                    Headline = "Weather goes SUPER HIGH WE'RE ALL ON FIRE OMGAH!!!!",
                    Body = "Atmosphere biosphere ceiling light celestial sphere clear ice cold constant pressure surface current hail heat land breeze mesosphere microburst national center for atmospheric research (ncar) nexrad occluded front range resolution specific humidity subpolar summer surface boundary layer wind wave. Beaufort wind scale cold core thunderstorms degree diablo winds diurnal dust bowl elevation flash flood greenhouse effect heat balance ice jam low level jet (llj) national oceanic and atmospheric administration (noaa) polar jet psychrometer pulse scattering standard atmosphere supercell undercast vertical visibility vorticity maximum wind chill index wind speed.",
                    CreationDate = new DateTime(2020, 08, 10),
                    CategoryID = 5,
                    AuthorID = 4
                },
                new Story
                {
                    Headline = "BARK BARK WORF WORF ARF GRRRRUF",
                    Body = "Doggo ipsum extremely cuuuuuute much ruin diet wrinkler pats smol heckin good boys dat tungg tho, adorable doggo clouds fluffer doggorino floofs. Corgo woofer waggy wags you are doing me a frighten, maximum borkdrive many pats. Waggy wags heck dat tungg tho porgo thicc, such treat many pats lotsa pats. Vvv many pats pupperino clouds long doggo yapper, boofers boof floofs many pats. Pupperino bork puggorino smol borking doggo with a long snoot for pats thicc yapper, blop ruff bork pats. Snoot borking doggo wow very biscit snoot long woofer, he made many woofs the neighborhood pupper. Very good spot pupper corgo, such treat. Extremely cuuuuuute noodle horse you are doing me a frighten very good spot, pats. Borking doggo maximum borkdrive woofer thicc, adorable doggo very taste wow blep, sub woofer big ol. He made many woofs boof long water shoob big ol pupper, you are doin me a concern puggo. I am bekom fat many pats wrinkler. Length boy wrinkler very hand that feed shibe you are doing me a frighten big ol, doge vvv adorable doggo you are doin me a concern you are doing me the shock, stop it fren blep boofers.",
                    CreationDate = new DateTime(2016, 10, 01),
                    CategoryID = 4,
                    AuthorID = 5
                }
            };

            Authors.ForEach(author =>
            {
                db.Authors.AddOrUpdate(a => a.Name, author);
            });

            Categories.ForEach(category =>
            {
                db.Categories.AddOrUpdate(c => c.Name, category);
            });

            Stories.ForEach(story =>
            {
                db.Stories.AddOrUpdate(s => s.Headline, story);
            });

            db.SaveChanges();
        }
    }
}
