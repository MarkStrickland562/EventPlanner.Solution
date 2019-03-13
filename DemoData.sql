USE event_planner;

INSERT INTO events (name, event_date, event_location)
VALUES ('July 4th BBQ', '2019-07-04', 'Woodland Park');

INSERT INTO events (name, event_date, event_location)
VALUES ('Easter Sunday Brunch', '2019-04-21', 'Casa de Marco');

INSERT INTO events (name, event_date, event_location)
VALUES ('St. Patricks Day Party', '2019-03-17', 'Clara''s House');

INSERT INTO menus (menu_theme) VALUES ('Summer BBQ');
INSERT INTO menus (menu_theme) VALUES ('Boozy Brunch');
INSERT INTO menus (menu_theme) VALUES ('Green Food or Potato Dishes');

UPDATE events SET menus_id = (SELECT id FROM menus where menu_theme = 'Summer BBQ')
WHERE name = 'July 4th BBQ';

UPDATE events SET menus_id = (SELECT id FROM menus where menu_theme = 'Boozy Brunch')
WHERE name = 'Easter Sunday Brunch';

UPDATE events SET menus_id = (SELECT id FROM menus where menu_theme = 'Green Food or Potato Dishes')
WHERE name = 'St. Patricks Day Party';

INSERT INTO menu_items (menu_item_description) VALUES ('Burgers');
INSERT INTO menu_items (menu_item_description) VALUES ('Hot Dogs');
INSERT INTO menu_items (menu_item_description) VALUES ('Potato Chips');
INSERT INTO menu_items (menu_item_description) VALUES ('Baked Beans');
INSERT INTO menu_items (menu_item_description) VALUES ('Cole Slaw');
INSERT INTO menu_items (menu_item_description) VALUES ('Iced Tea');

INSERT INTO menu_items (menu_item_description) VALUES ('Bacon');
INSERT INTO menu_items (menu_item_description) VALUES ('Quiche Lorraine');
INSERT INTO menu_items (menu_item_description) VALUES ('Hash Browns');
INSERT INTO menu_items (menu_item_description) VALUES ('Fruit Salad');
INSERT INTO menu_items (menu_item_description) VALUES ('Cinnamon Rolls');
INSERT INTO menu_items (menu_item_description) VALUES ('Bloody Marys');

INSERT INTO menu_items (menu_item_description) VALUES ('Corned Beef');
INSERT INTO menu_items (menu_item_description) VALUES ('Scalloped Potatoes');
INSERT INTO menu_items (menu_item_description) VALUES ('Brussels Sprouts');
INSERT INTO menu_items (menu_item_description) VALUES ('Soda Bread');
INSERT INTO menu_items (menu_item_description) VALUES ('Irish Whiskey');

INSERT INTO menu_items (menu_item_description) VALUES ('Condiments');

INSERT INTO menus_menu_items (menus_id, menu_items_id)
SELECT a.menus_id, b.menu_items_id
FROM (SELECT id AS menus_id FROM menus WHERE menu_theme = 'Summer BBQ') AS a
JOIN (SELECT id AS menu_items_id FROM menu_items WHERE menu_item_description = 'Burgers') as b ON 1=1;

INSERT INTO menus_menu_items (menus_id, menu_items_id)
SELECT a.menus_id, b.menu_items_id
FROM (SELECT id AS menus_id FROM menus WHERE menu_theme = 'Summer BBQ') AS a
JOIN (SELECT id AS menu_items_id FROM menu_items WHERE menu_item_description = 'Hot Dogs') as b ON 1=1;

INSERT INTO menus_menu_items (menus_id, menu_items_id)
SELECT a.menus_id, b.menu_items_id
FROM (SELECT id AS menus_id FROM menus WHERE menu_theme = 'Summer BBQ') AS a
JOIN (SELECT id AS menu_items_id FROM menu_items WHERE menu_item_description = 'Potato Chips') as b ON 1=1;

INSERT INTO menus_menu_items (menus_id, menu_items_id)
SELECT a.menus_id, b.menu_items_id
FROM (SELECT id AS menus_id FROM menus WHERE menu_theme = 'Summer BBQ') AS a
JOIN (SELECT id AS menu_items_id FROM menu_items WHERE menu_item_description = 'Baked Beans') as b ON 1=1;

INSERT INTO menus_menu_items (menus_id, menu_items_id)
SELECT a.menus_id, b.menu_items_id
FROM (SELECT id AS menus_id FROM menus WHERE menu_theme = 'Summer BBQ') AS a
JOIN (SELECT id AS menu_items_id FROM menu_items WHERE menu_item_description = 'Cole Slaw') as b ON 1=1;

INSERT INTO menus_menu_items (menus_id, menu_items_id)
SELECT a.menus_id, b.menu_items_id
FROM (SELECT id AS menus_id FROM menus WHERE menu_theme = 'Summer BBQ') AS a
JOIN (SELECT id AS menu_items_id FROM menu_items WHERE menu_item_description = 'Iced Tea') as b ON 1=1;

INSERT INTO menus_menu_items (menus_id, menu_items_id)
SELECT a.menus_id, b.menu_items_id
FROM (SELECT id AS menus_id FROM menus WHERE menu_theme = 'Summer BBQ') AS a
JOIN (SELECT id AS menu_items_id FROM menu_items WHERE menu_item_description = 'BBQ Condiments') as b ON 1=1;

INSERT INTO menus_menu_items (menus_id, menu_items_id)
SELECT a.menus_id, b.menu_items_id
FROM (SELECT id AS menus_id FROM menus WHERE menu_theme = 'Boozy Brunch') AS a
JOIN (SELECT id AS menu_items_id FROM menu_items WHERE menu_item_description = 'Bacon') as b ON 1=1;

INSERT INTO menus_menu_items (menus_id, menu_items_id)
SELECT a.menus_id, b.menu_items_id
FROM (SELECT id AS menus_id FROM menus WHERE menu_theme = 'Boozy Brunch') AS a
JOIN (SELECT id AS menu_items_id FROM menu_items WHERE menu_item_description = 'Quiche Lorraine') as b ON 1=1;

INSERT INTO menus_menu_items (menus_id, menu_items_id)
SELECT a.menus_id, b.menu_items_id
FROM (SELECT id AS menus_id FROM menus WHERE menu_theme = 'Boozy Brunch') AS a
JOIN (SELECT id AS menu_items_id FROM menu_items WHERE menu_item_description = 'Hash Browns') as b ON 1=1;

INSERT INTO menus_menu_items (menus_id, menu_items_id)
SELECT a.menus_id, b.menu_items_id
FROM (SELECT id AS menus_id FROM menus WHERE menu_theme = 'Boozy Brunch') AS a
JOIN (SELECT id AS menu_items_id FROM menu_items WHERE menu_item_description = 'Fruit Salad') as b ON 1=1;

INSERT INTO menus_menu_items (menus_id, menu_items_id)
SELECT a.menus_id, b.menu_items_id
FROM (SELECT id AS menus_id FROM menus WHERE menu_theme = 'Boozy Brunch') AS a
JOIN (SELECT id AS menu_items_id FROM menu_items WHERE menu_item_description = 'Cinnamon Rolls') as b ON 1=1;

INSERT INTO menus_menu_items (menus_id, menu_items_id)
SELECT a.menus_id, b.menu_items_id
FROM (SELECT id AS menus_id FROM menus WHERE menu_theme = 'Boozy Brunch') AS a
JOIN (SELECT id AS menu_items_id FROM menu_items WHERE menu_item_description = 'Bloody Marys') as b ON 1=1;

INSERT INTO menus_menu_items (menus_id, menu_items_id)
SELECT a.menus_id, b.menu_items_id
FROM (SELECT id AS menus_id FROM menus WHERE menu_theme = 'Green Food or Potato Dishes') AS a
JOIN (SELECT id AS menu_items_id FROM menu_items WHERE menu_item_description = 'Corned Beef') as b ON 1=1;

INSERT INTO menus_menu_items (menus_id, menu_items_id)
SELECT a.menus_id, b.menu_items_id
FROM (SELECT id AS menus_id FROM menus WHERE menu_theme = 'Green Food or Potato Dishes') AS a
JOIN (SELECT id AS menu_items_id FROM menu_items WHERE menu_item_description = 'Scalloped Potatoes') as b ON 1=1;

INSERT INTO menus_menu_items (menus_id, menu_items_id)
SELECT a.menus_id, b.menu_items_id
FROM (SELECT id AS menus_id FROM menus WHERE menu_theme = 'Green Food or Potato Dishes') AS a
JOIN (SELECT id AS menu_items_id FROM menu_items WHERE menu_item_description = 'Brussels Sprouts') as b ON 1=1;

INSERT INTO menus_menu_items (menus_id, menu_items_id)
SELECT a.menus_id, b.menu_items_id
FROM (SELECT id AS menus_id FROM menus WHERE menu_theme = 'Green Food or Potato Dishes') AS a
JOIN (SELECT id AS menu_items_id FROM menu_items WHERE menu_item_description = 'Soda Bread') as b ON 1=1;

INSERT INTO menus_menu_items (menus_id, menu_items_id)
SELECT a.menus_id, b.menu_items_id
FROM (SELECT id AS menus_id FROM menus WHERE menu_theme = 'Green Food or Potato Dishes') AS a
JOIN (SELECT id AS menu_items_id FROM menu_items WHERE menu_item_description = 'Irish Whiskey') as b ON 1=1;

INSERT INTO stores (store_name) VALUES ('Costco');
INSERT INTO stores (store_name) VALUES ('Cash & Carry');
INSERT INTO stores (store_name) VALUES ('Grocery Outlet');
INSERT INTO stores (store_name) VALUES ('QFC');
INSERT INTO stores (store_name) VALUES ('Trader Joe''s');

INSERT INTO menu_item_ingredients (ingredient_description, menu_items_id, store_id)
SELECT 'Ground Beef, 10#', a.menu_items_id, b.store_id
FROM (SELECT id AS menu_items_id FROM menu_items WHERE menu_item_description = 'Burgers') as a
JOIN (SELECT id AS store_id FROM stores WHERE store_name = 'Cash & Carry') as b
ON 1=1;

INSERT INTO menu_item_ingredients (ingredient_description, menu_items_id, store_id)
SELECT 'Hot Dogs, 3-Dozen', a.menu_items_id, b.store_id
FROM (SELECT id AS menu_items_id FROM menu_items WHERE menu_item_description = 'Hot Dogs') as a
JOIN (SELECT id AS store_id FROM stores WHERE store_name = 'Cash & Carry') as b
ON 1=1;

INSERT INTO menu_item_ingredients (ingredient_description, menu_items_id, store_id)
SELECT 'Baked Beans, #10 Can', a.menu_items_id, b.store_id
FROM (SELECT id AS menu_items_id FROM menu_items WHERE menu_item_description = 'Baked Beans') as a
JOIN (SELECT id AS store_id FROM stores WHERE store_name = 'Cash & Carry') as b
ON 1=1;

INSERT INTO menu_item_ingredients (ingredient_description, menu_items_id, store_id)
SELECT 'Potato Chips, 2 Large Bags', a.menu_items_id, b.store_id
FROM (SELECT id AS menu_items_id FROM menu_items WHERE menu_item_description = 'Potato Chips') as a
JOIN (SELECT id AS store_id FROM stores WHERE store_name = 'Costco') as b
ON 1=1;

INSERT INTO menu_item_ingredients (ingredient_description, menu_items_id, store_id)
SELECT 'Cole Slaw, 1 Tub', a.menu_items_id, b.store_id
FROM (SELECT id AS menu_items_id FROM menu_items WHERE menu_item_description = 'Cole Slaw') as a
JOIN (SELECT id AS store_id FROM stores WHERE store_name = 'Costco') as b
ON 1=1;

INSERT INTO menu_item_ingredients (ingredient_description, menu_items_id, store_id)
SELECT 'Hamburger Buns, 3-Dozen', a.menu_items_id, b.store_id
FROM (SELECT id AS menu_items_id FROM menu_items WHERE menu_item_description = 'Burgers') as a
JOIN (SELECT id AS store_id FROM stores WHERE store_name = 'QFC') as b
ON 1=1;

INSERT INTO menu_item_ingredients (ingredient_description, menu_items_id, store_id)
SELECT 'Hot Dog Buns, 3-Dozen', a.menu_items_id, b.store_id
FROM (SELECT id AS menu_items_id FROM menu_items WHERE menu_item_description = 'Hot Dogs') as a
JOIN (SELECT id AS store_id FROM stores WHERE store_name = 'QFC') as b
ON 1=1;

INSERT INTO menu_item_ingredients (ingredient_description, menu_items_id, store_id)
SELECT 'Tea Bags, Lipton, 1 Box', a.menu_items_id, b.store_id
FROM (SELECT id AS menu_items_id FROM menu_items WHERE menu_item_description = 'Iced Tea') as a
JOIN (SELECT id AS store_id FROM stores WHERE store_name = 'QFC') as b
ON 1=1;

INSERT INTO menu_item_ingredients (ingredient_description, menu_items_id, store_id)
SELECT 'Ketchup, Mayonnaise, Mustard, Relish', a.menu_items_id, b.store_id
FROM (SELECT id AS menu_items_id FROM menu_items WHERE menu_item_description = 'BBQ Condiments') as a
JOIN (SELECT id AS store_id FROM stores WHERE store_name = 'Grocery Outlet') as b
ON 1=1;

INSERT INTO menu_item_ingredients (ingredient_description, menu_items_id, store_id)
SELECT 'Bacon, 4#', a.menu_items_id, b.store_id
FROM (SELECT id AS menu_items_id FROM menu_items WHERE menu_item_description = 'Bacon') as a
JOIN (SELECT id AS store_id FROM stores WHERE store_name = 'Costco') as b
ON 1=1;

INSERT INTO menu_item_ingredients (ingredient_description, menu_items_id, store_id)
SELECT 'Eggs, 2-Dozen', a.menu_items_id, b.store_id
FROM (SELECT id AS menu_items_id FROM menu_items WHERE menu_item_description = 'Quiche Lorraine') as a
JOIN (SELECT id AS store_id FROM stores WHERE store_name = 'Trader Joe''s') as b
ON 1=1;

INSERT INTO menu_item_ingredients (ingredient_description, menu_items_id, store_id)
SELECT 'Heavy Cream, 1-Quart', a.menu_items_id, b.store_id
FROM (SELECT id AS menu_items_id FROM menu_items WHERE menu_item_description = 'Quiche Lorraine') as a
JOIN (SELECT id AS store_id FROM stores WHERE store_name = 'QFC') as b
ON 1=1;

INSERT INTO menu_item_ingredients (ingredient_description, menu_items_id, store_id)
SELECT 'Pie Shells, 4', a.menu_items_id, b.store_id
FROM (SELECT id AS menu_items_id FROM menu_items WHERE menu_item_description = 'Quiche Lorraine') as a
JOIN (SELECT id AS store_id FROM stores WHERE store_name = 'QFC') as b
ON 1=1;

INSERT INTO menu_item_ingredients (ingredient_description, menu_items_id, store_id)
SELECT 'Potatoes, 5# Bag', a.menu_items_id, b.store_id
FROM (SELECT id AS menu_items_id FROM menu_items WHERE menu_item_description = 'Hash Browns') as a
JOIN (SELECT id AS store_id FROM stores WHERE store_name = 'Grocery Outlet') as b
ON 1=1;

INSERT INTO menu_item_ingredients (ingredient_description, menu_items_id, store_id)
SELECT 'Butter, 1#', a.menu_items_id, b.store_id
FROM (SELECT id AS menu_items_id FROM menu_items WHERE menu_item_description = 'Hash Browns') as a
JOIN (SELECT id AS store_id FROM stores WHERE store_name = 'Trader Joe''s') as b
ON 1=1;

INSERT INTO menu_item_ingredients (ingredient_description, menu_items_id, store_id)
SELECT 'Fruit Assortment, 2 Tubs', a.menu_items_id, b.store_id
FROM (SELECT id AS menu_items_id FROM menu_items WHERE menu_item_description = 'Fruit Salad') as a
JOIN (SELECT id AS store_id FROM stores WHERE store_name = 'Costco') as b
ON 1=1;

INSERT INTO menu_item_ingredients (ingredient_description, menu_items_id, store_id)
SELECT 'Cinnamon Rolls, 4 Cans', a.menu_items_id, b.store_id
FROM (SELECT id AS menu_items_id FROM menu_items WHERE menu_item_description = 'Cinnamon Rolls') as a
JOIN (SELECT id AS store_id FROM stores WHERE store_name = 'QFC') as b
ON 1=1;

INSERT INTO menu_item_ingredients (ingredient_description, menu_items_id, store_id)
SELECT 'Bloody Mary Mix, 2 Bottles', a.menu_items_id, b.store_id
FROM (SELECT id AS menu_items_id FROM menu_items WHERE menu_item_description = 'Bloody Marys') as a
JOIN (SELECT id AS store_id FROM stores WHERE store_name = 'Cash & Carry') as b
ON 1=1;

INSERT INTO menu_item_ingredients (ingredient_description, menu_items_id, store_id)
SELECT 'Vodka, 2-Litres', a.menu_items_id, b.store_id
FROM (SELECT id AS menu_items_id FROM menu_items WHERE menu_item_description = 'Bloody Marys') as a
JOIN (SELECT id AS store_id FROM stores WHERE store_name = 'QFC') as b
ON 1=1;

INSERT INTO menu_item_ingredients (ingredient_description, menu_items_id, store_id)
SELECT 'Beef Brisket, 5#', a.menu_items_id, b.store_id
FROM (SELECT id AS menu_items_id FROM menu_items WHERE menu_item_description = 'Corned Beef') as a
JOIN (SELECT id AS store_id FROM stores WHERE store_name = 'Cash & Carry') as b
ON 1=1;

INSERT INTO menu_item_ingredients (ingredient_description, menu_items_id, store_id)
SELECT 'Corned Beef Spices', a.menu_items_id, b.store_id
FROM (SELECT id AS menu_items_id FROM menu_items WHERE menu_item_description = 'Corned Beef') as a
JOIN (SELECT id AS store_id FROM stores WHERE store_name = 'QFC') as b
ON 1=1;

INSERT INTO menu_item_ingredients (ingredient_description, menu_items_id, store_id)
SELECT 'Red Potatoes, 5#', a.menu_items_id, b.store_id
FROM (SELECT id AS menu_items_id FROM menu_items WHERE menu_item_description = 'Scallopped Potatoes') as a
JOIN (SELECT id AS store_id FROM stores WHERE store_name = 'Grocery Outlet') as b
ON 1=1;

INSERT INTO menu_item_ingredients (ingredient_description, menu_items_id, store_id)
SELECT '1/2 and 1/2, 2-Quarts', a.menu_items_id, b.store_id
FROM (SELECT id AS menu_items_id FROM menu_items WHERE menu_item_description = 'Scallopped Potatoes') as a
JOIN (SELECT id AS store_id FROM stores WHERE store_name = 'Cash & Carry') as b
ON 1=1;

INSERT INTO menu_item_ingredients (ingredient_description, menu_items_id, store_id)
SELECT 'Brussels Sprouts, Frozen, 2#', a.menu_items_id, b.store_id
FROM (SELECT id AS menu_items_id FROM menu_items WHERE menu_item_description = 'Brussels Sprouts') as a
JOIN (SELECT id AS store_id FROM stores WHERE store_name = 'QFC') as b
ON 1=1;

INSERT INTO menu_item_ingredients (ingredient_description, menu_items_id, store_id)
SELECT 'Soda Bread, 2-Dozen Pieces', a.menu_items_id, b.store_id
FROM (SELECT id AS menu_items_id FROM menu_items WHERE menu_item_description = 'Soda Bread') as a
JOIN (SELECT id AS store_id FROM stores WHERE store_name = 'Trader Joe''s') as b
ON 1=1;

INSERT INTO menu_item_ingredients (ingredient_description, menu_items_id, store_id)
SELECT 'Irish Whiskey, 2-Litres', a.menu_items_id, b.store_id
FROM (SELECT id AS menu_items_id FROM menu_items WHERE menu_item_description = 'Irish Whiskey') as a
JOIN (SELECT id AS store_id FROM stores WHERE store_name = 'Costco') as b
ON 1=1;
