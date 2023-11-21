CREATE DATABASE GiftInfoDB;
GO

USE GiftInfoDB;
GO

SET ANSI_NULLS ON;
GO

SET QUOTED_IDENTIFIER ON;
GO

CREATE TABLE dbo.GiftInfo (
    GiftId      INT            IDENTITY (1, 1) PRIMARY KEY,
    GiftName    NVARCHAR(255)  NOT NULL,
    Description NVARCHAR(500)  NOT NULL,
    GiftPrice   DECIMAL(10, 2) NOT NULL,
    GiftAge     INT,
    GiftCategory NVARCHAR(100),
    GiftGender  NVARCHAR(100),
    GiftURL NVARCHAR(600)
   
);
GO

INSERT INTO dbo.GiftInfo (GiftName, Description, GiftPrice, GiftAge, GiftCategory, GiftGender, GiftURL) 
VALUES (
    'LEGO Arctic Explorer Ship',
    'This huge floatable toy boat is loaded with realistic detailing for imaginative exploration adventures. This premium playset also includes a helicopter, dinghy, underwater ROV sub and a Viking shipwreck, plus a treasure chest, 7 minifigures and an orca figure.',
    209.99,
    7,
    'Toys',
    'Unisex',
    'https://www.lego.com/en-ca/product/arctic-explorer-ship-60368?gclid=CjwKCAiAgeeqBhBAEiwAoDDhn7nKEEjjXGV3tmXCs7p-Hzjp3I8jOv3jeDQVOa01Dytjw1QsC6svLxoC_3AQAvD_BwE&ef_id=CjwKCAiAgeeqBhBAEiwAoDDhn7nKEEjjXGV3tmXCs7p-Hzjp3I8jOv3jeDQVOa01Dytjw1QsC6svLxoC_3AQAvD_BwE:G:s&s_kwcid=AL!790!3!!!!x!!!20535543328!&cmp=KAC-INI-GOOGUS-GO-CA_GL-RE-SP-BUY-CREATE-PLA-SHOP-BP-SP-ALL-CIDNA00000-PMAX_MEDIUM_PRIORITY&gad_source=1'
);
INSERT INTO dbo.GiftInfo (GiftName, Description, GiftPrice, GiftAge, GiftCategory, GiftGender, GiftURL) 
VALUES (
    'Cake Pop Maker',
    'Bake 12 cake pops or doughnut holes in minutes.
     Nonstick baking plates for ideal results and easy clean up',
    89.98,
	12,
    'Baking',
    'Unisex', 
    'https://www.amazon.ca/Babycakes-CP-12-Maker-Capacity-Purple/dp/B0050JRZR2/ref=asc_df_B0050JRZR2/?tag=googleshopc0c-20&linkCode=df0&hvadid=292936221072&hvpos=&hvnetw=g&hvrand=11720506141824373293&hvpone=&hvptwo=&hvqmt=&hvdev=c&hvdvcmdl=&hvlocint=&hvlocphy=1002161&hvtargid=pla-572573147915&psc=1&mcid=08f13ebbcf08339eb6ab2f5a1767d8dc'
    
);
INSERT INTO dbo.GiftInfo (GiftName, Description, GiftPrice, GiftAge, GiftCategory, GiftGender, GiftURL) 
VALUES (
    'Kids Makeup Kit for Girls',
    'Teensymic kids makeup kit toys for girls our brand have passed the American toy safety test, The size of the kids makeup kit for girl is also designed according to the size suitable for little girls.',
    45.99,
	4,
    'Makeup',
    'Girls',
    'https://www.amazon.ca/Makeup-Teensymic-Washable-Princess-Birthday/dp/B0BM8W1L2S/ref=asc_df_B0BM8W1L2S/?tag=googleshopc0c-20&linkCode=df0&hvadid=580885861616&hvpos=&hvnetw=g&hvrand=17604544272217293590&hvpone=&hvptwo=&hvqmt=&hvdev=c&hvdvcmdl=&hvlocint=&hvlocphy=1002161&hvtargid=pla-1969372472600&psc=1&mcid=b1fca9d16f3a3ecea8d94146407cc6b9'
    
);
INSERT INTO dbo.GiftInfo (GiftName, Description, GiftPrice, GiftAge, GiftCategory, GiftGender, GiftURL) 
VALUES (
    'Girls Unicorn BFF Locket - 2pck',
    '100% metal
Pack of 2 locket necklaces.
Glitter heart locket with unicorn graphic.
Attached BFF charm.
Lobster clasp closure and extender.
Recommended for ages 4 and up ',
    5.98,
	4,
    'Jewelry',
    'Girls',
    'https://www.childrensplace.com/ca/p/Girls-Unicorn-BFF-Locket-Necklace-2-Pack-3043141-BQ?utm_source=googlepla&cid=CSE-_-CAGooglePLA-_-PMAXAllProducts-_-AllProducts-_-00196733914209&gad_source=1&gclid=CjwKCAiAgeeqBhBAEiwAoDDhnzr02KSPrfa0yqJl6cXNVjyRohXlPNj-WxpSnGCwT5-ua25wSjZdRxoCUJMQAvD_BwE'
    
);
INSERT INTO dbo.GiftInfo (GiftName, Description, GiftPrice, GiftAge, GiftCategory, GiftGender, GiftURL) 
VALUES (
    'Beyblade SpeedStorm Battle Set',
    'Supercharge the battle strategy with Beyblade Burst Speedstorm tech! Launch into a highspeed head-to-head in the official Beyblade Burst Speedstorm Motor Strike Beystadium by Hasbro -- the first motorized Beyblade stadium in the Beyblade Burst line. ',
    53.10,
	8,
    'Toys',
    'Boys',
    'https://www.walmart.com/ip/Beyblade-Burst-Surge-Speedstorm-Motor-Strike-Battle-Set-Battle-Game-Playset-with-Motorized-Beyblade-Stadium/784231218?clickid=WAzzphUAcxyPRDmVY4w9EW9qUkFX2uRuXQG2yg0&irgwc=1&sourceid=imp_WAzzphUAcxyPRDmVY4w9EW9qUkFX2uRuXQG2yg0&veh=aff&wmlspartner=imp_10078&affiliates_ad_id=612734&campaign_id=9383&sharedid=rd.com'
    
);

INSERT INTO dbo.GiftInfo (GiftName, Description, GiftPrice, GiftAge, GiftCategory, GiftGender, GiftURL) 
VALUES (
    'Carrera Slot Car Racing Track Set',
    'Fast-paced car racing action on 14.10-ft of track with realistic cars that reach scale speeds of 370-mph',
    47.21,
	5,
    'Toys',
    'Boys',
    'https://www.amazon.com/Carrera-63504-Speed-Battery-Operated/dp/B07PKDN44F?tag=readerwp-20&asc_refurl=https%3A%2F%2Fwww.rd.com%2Flist%2Fgifts-for-boys%2F&asc_source=https%3A%2F%2Fwww.google.com%2F&th=1'
    
);

INSERT INTO dbo.GiftInfo (GiftName, Description, GiftPrice, GiftAge, GiftCategory, GiftGender, GiftURL) 
VALUES (
    'Swarovski Womens Bella V Drop Earrings',
    'Keep it simple and chic with this elegant and feminine pair of rhodium-plated pierced earrings. Showcasing beautiful round clear crystals, accented with a hint of clear crystal pavé, they complement any outfit and will take you from day to night in perfect style.',
    55.00,
	16,
    'Jewelry',
    'Womens',
    'https://www.swarovski.com/en_GB-CA/p-M5292855/Bella-V-drop-earrings-Round-cut-White-Rhodium-plated/?variantID=5292855&utm_source=google&utm_medium=cpc&utm_campaign=&utm_adgroup=&utm_term=&creative=&device=c&placement=&gad_source=1&gclid=CjwKCAiAgeeqBhBAEiwAoDDhn7Rd_0WVIbuDFyHw-gJbpxZpKV5ROwbTefYEh8nRxitdOcPvNvDUThoCQlUQAvD_BwE&gclsrc=aw.ds'
);

INSERT INTO dbo.GiftInfo (GiftName, Description, GiftPrice, GiftAge, GiftCategory, GiftGender, GiftURL) 
VALUES (
    'MAC Cosmetics Merry Must Haves',
    'A holiday-exclusive five-piece kit for eyes, lips and skin featuring best-selling Lustreglass Lipstick, Eye Shadow, M·A·CStack Mascara, Fix+ and a mini Hyper Real Serumizer.',
    75.00,
	15,
    'Makeup',
    'Womens',
    'https://www.maccosmetics.ca/product/13835/120445/products/makeup/eyes/eye-palettes-kits/merry-must-haves?gad_source=1&gclid=CjwKCAiAgeeqBhBAEiwAoDDhn1oDTu0RUhrbPWpbjCKK6hZzo_ITNwd2vB6djuRw-_Q4hHg43vQG-hoCrfEQAvD_BwE&gclsrc=aw.ds'
);

INSERT INTO dbo.GiftInfo (GiftName, Description, GiftPrice, GiftAge, GiftCategory, GiftGender, GiftURL) 
VALUES (
    'TRAVANDO Slim Wallet with Money Clip',
    'The designer wallet offers 11 card pockets; The outside notch allows you to push out the cards easily; Ideal for carrying business, credit cards and bills',
    78.12,
	15,
    'Wallets',
    'Mens',
    'https://www.amazon.ca/dp/B09V1B4LYP?slotNum=24&ots=1&ascsubtag=%5Bartid%7C10055.g.399%5Bsrc%7Carb_ga_ghk_md_dsa_comm_mix_ca_20497754392%5Bch%7C0662134eb3a8cda62c0acbb25d52d53c%5Blt%7Csale%5Bpid%7Ce47d6079-9251-4ae2-b40e-8d239e8f803a&linkCode=gg2&imprToken=e6c5f4f1-71c1-daa5-4da&tag=ghk-lift-20&th=1'
);

INSERT INTO dbo.GiftInfo (GiftName, Description, GiftPrice, GiftAge, GiftCategory, GiftGender, GiftURL) 
VALUES (
    'The Beard Hedger Advanced Kit',
    'Our precision beard groomer comes equipped with an intuitive zoom wheel with 20 different lengths (.5mm increments) to choose from so you can ditch the dozen clipper attachments and trim anything from a lumberjack stache to stubble.',
    164.99,
	15,
    'Shaving and Hair Removal',
    'Mens',
    'https://www.amazon.ca/dp/B0BQ1KR2QD?slotNum=22&ots=1&ascsubtag=[artid|2139.g.37927738[src|arb_ga_mnh_md_dsa_comm_mix_ca_19856649761[ch|397c8f33cb4584d576d4f4788ea917fe[lt|[pid|e3ee8120-0815-4d79-84d0-fa5b5fbd9c39&linkCode=gg2&imprToken=68c5f4f2-73b3-7509-3c4&tag=mh-lift-20'
);
GO

CREATE TABLE dbo.UserInfo (
    UserId      INT  IDENTITY (1, 1) PRIMARY KEY,
    UserName    NVARCHAR(100)  NOT NULL,
    Email       NVARCHAR(100)  NOT NULL,
    UserPass  NVARCHAR(100) NOT NULL
   
);
GO

CREATE TABLE dbo.UserFavoriteGift (
    UserFavoriteGiftId INT IDENTITY (1, 1) PRIMARY KEY,
    UserId             INT,
    GiftId             INT,
    FOREIGN KEY (UserId) REFERENCES dbo.UserInfo(UserId),
    FOREIGN KEY (GiftId) REFERENCES dbo.GiftInfo(GiftId)
);


 