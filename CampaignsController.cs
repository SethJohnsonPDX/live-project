public ViewResult Index(string sortOrder, string searchString)
        {
            // Sort Order
            ViewBag.StartDateDescSortParm = "startDate_desc";
            ViewBag.StartDateSortParm = "startDate";
            ViewBag.SalePriceSortParm = "salePrice";
            ViewBag.SalePriceDescSortParm = "salePrice_desc";
            // Category Filter
            ViewBag.ClothingCatParm = "clothing";
            ViewBag.FoodDrinkCatParm = "foodDrink";
            ViewBag.HealthBeautyCatParm = "healthBeauty";
            ViewBag.HomeProductCatParm = "homeProducts";
            ViewBag.ChildrenCatParm = "children";
            ViewBag.TechnologyCatParm = "technology";
            ViewBag.MiscCatParm = "miscellaneous";
            var campaigns = from c in db.Campaigns.Include(c => c.ApplicationUser)
                            select c;
                case "salePrice_desc":
                    campaigns = campaigns.OrderByDescending(c => c.SalePrice);
                    break;
                case "clothing":
                    campaigns = campaigns.Where(c => c.CampaignCategories == Categories.Clothing);
                    break;
                case "foodDrink":
                    campaigns = campaigns.Where(c => c.CampaignCategories == Categories.FoodAndDrink);
                    break;
                case "healthBeauty":
                    campaigns = campaigns.Where(c => c.CampaignCategories == Categories.HealthAndBeauty);
                    break;
                case "homeProducts":
                    campaigns = campaigns.Where(c => c.CampaignCategories == Categories.HomeProducts);
                    break;
                case "children":
                    campaigns = campaigns.Where(c => c.CampaignCategories == Categories.Children);
                    break;
                case "technology":
                    campaigns = campaigns.Where(c => c.CampaignCategories == Categories.Technology);
                    break;
                case "miscellaneous":
                    campaigns = campaigns.Where(c => c.CampaignCategories == Categories.Miscellaneous);
                    break;
                default:
                    campaigns = campaigns.OrderByDescending(c => c.StartDate);
            return RedirectToAction("Index");
        }
        public ActionResult AdminView(string sortOrder)
        {
            ViewBag.UserNameSortParm = sortOrder == "userName" ? "userName_desc" : "userName";
