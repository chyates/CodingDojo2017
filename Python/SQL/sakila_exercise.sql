-- all the customers inside city_id 312, returns first name, last name, email, address
 SELECT address.city_id, customer.first_name, customer.last_name, customer.email, address.address
 FROM customer LEFT JOIN address ON customer.address_id = address.address_id
 WHERE address.city_id = 312;

-- all comedy films, returning film_title, description, release_year, rating, special features, genre
 SELECT film.film_id, film.title, film.description, film.release_year, film.rating, film.special_features, category.name AS genre
 FROM film LEFT JOIN film_category ON film.film_id = film_category.film_id LEFT JOIN category ON film_category.category_id = category.category_id
 WHERE category.name = 'Comedy';

-- all films joined by actor_id = 5, returning actor id, actor name, film title, description, release year
 SELECT actor.actor_id, actor.first_name, actor.last_name, film.title, film.description, film.release_year
 FROM actor JOIN film_actor ON film_actor.actor_id=actor.actor_id JOIN film ON film.film_id=film_actor.film_id
 WHERE actor.actor_id = 5;

-- all customers in store_id = 1 and inside cities (1, 42, 312, 459), return customer first name, last name, email, and address
SELECT store.store_id, city.city_id, customer.first_name, customer.last_name, customer.email, address.address
 FROM customer LEFT JOIN address ON customer.address_id = address.address_id LEFT JOIN store ON customer.store_id = store.store_id LEFT JOIN city ON address.city_id = city.city_id
 WHERE store.store_id = 1 AND city.city_id IN (1,42,312,459);

-- all films with a rating of G and special feature of behind the scenes, joined by actor_id = 15; return film title, description, release year, rating, and special feature
 SELECT film.title, film.description, film.release_year, film.rating, film.special_features
 FROM film JOIN film_actor ON film.film_id=film_actor.film_id JOIN actor ON film_actor.actor_id=actor.actor_id
 WHERE film.rating LIKE 'G' AND actor.actor_id = 15 AND film.special_features LIKE '%behind the scenes';

-- all actors that joined in the film_id = 269, returns the film id, title, actor id, and actor name
 SELECT film.film_id, film.title, actor.actor_id, CONCAT(actor.first_name, "", actor.last_name) AS actor_name
 FROM film LEFT JOIN film_actor ON film.film_id=film_actor.film_id LEFT JOIN actor ON film_actor.actor_id = actor.actor_id
 WHERE film.film_id = 369;

-- all drama films with a rental rate of 2.99, returns film title, description, release year, rating, special features, and genre
 SELECT film.title, film.description, film.release_year, film.rental_rate, film.special_features, category.name AS genre
 FROM film LEFT JOIN film_category ON film.film_id=film_category.film_id LEFT JOIN category ON category.category_id=film_category.category_id
 WHERE film.rental_rate = 2.99 AND category.name LIKE 'Drama';

-- all action films joined by actor name = sandra kilmer, returns film title, description, release year, rating, special features, genre, and actor first/last name
 SELECT actor.actor_id, CONCAT(actor.first_name, "", actor.last_name) AS actor_name, film.title, film.description, film.release_year, film.rating, film.special_features, category.name
 FROM film LEFT JOIN film_category ON film.film_id=film_category.film_id LEFT JOIN category ON category.category_id = film_category.category_id
 LEFT JOIN film_actor ON film_actor.film_id=film.film_id LEFT JOIN actor ON actor.actor_id=film_actor.actor_id
 WHERE category.name LIKE 'Action' AND (actor.first_name = 'Sandra' AND actor.last_name = 'Kilmer');