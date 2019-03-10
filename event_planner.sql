DROP DATABASE IF EXISTS event_planner;

CREATE DATABASE IF NOT EXISTS event_planner;

USE event_planner;

CREATE TABLE menus (id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                    menu_theme VARCHAR(255) NOT NULL)
                    ENGINE=InnoDB;

CREATE TABLE events (id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                     name VARCHAR(255) NOT NULL,
                     event_date DATETIME NOT NULL,
                     event_location VARCHAR(255) NOT NULL,
                     menus_id INT)
                     ENGINE=InnoDB;

CREATE TABLE menu_items (id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                         menu_item_description VARCHAR(255) NOT NULL)
                         ENGINE=InnoDB;

CREATE TABLE stores (id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                     store_name VARCHAR(255) NOT NULL)
                     ENGINE=InnoDB;

CREATE TABLE tasks (id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                    task_description VARCHAR(255) NOT NULL,
                    planned_start_datetime DATETIME)
                    ENGINE=InnoDB;

CREATE TABLE invitees (id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                       invitee_name VARCHAR(255) NOT NULL,
                       invitee_email_address VARCHAR(255))
                       ENGINE=InnoDB;

CREATE TABLE menu_item_ingredients (id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                                    ingredient_description VARCHAR(255) NOT NULL,
                                    menu_items_id INT,
                                    store_id INT)
                                    ENGINE=InnoDB;

CREATE TABLE events_tasks (id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                           events_id INT,
                           tasks_id INT)
                           ENGINE=InnoDB;

CREATE TABLE events_invitees (id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                              events_id INT,
                              invitees_id INT)
                              ENGINE=InnoDB;

CREATE TABLE menus_menu_items (id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                               menus_id INT,
                               menu_items_id INT)
                               ENGINE=InnoDB;
