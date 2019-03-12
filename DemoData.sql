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
