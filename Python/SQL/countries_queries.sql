-- all countries that speak slovene: name of country, name of language, % of language in desc order
SELECT countries.name, languages.language, languages.percentage 
FROM countries LEFT JOIN languages ON languages.country_id = countries.id 
WHERE languages.name = 'Slovene'
ORDER BY languages.percentage desc;

-- display total # of cities in each country (returns name of country and # of cities, arranged by # of cities desc)
SELECT countries.name, COUNT(cities.name) AS city_count
FROM countries LEFT JOIN cities ON countries.id=cities.country_id
GROUP BY countries.name
ORDER BY city_count desc;

-- all cities in Mexico with a pop > 500,000; arrange by pop in desc order
SELECT name, population
FROM cities 
WHERE country_code = 'MEX' AND population > 500000
ORDER BY population desc;

-- all languages in each country with a percent > 89; arrange pop in desc order
SELECT countries.name, languages.language, languages.percentage
FROM languages LEFT JOIN countries ON languages.country_id=countries.id
WHERE languages.percentage > 0.89
ORDER BY languages.percentage DESC;

-- all the countries with surface area < 501 and pop > 100000
SELECT name 
FROM countries
WHERE surface_area < 501 and population > 100000;

-- countries with only a constitutional monarchy and a capital > 200 and life expectancy > 75 years
SELECT name, government_form, capital, life_expectancy
FROM countries
WHERE government_form = 'Constitutional Monarchy' AND capital > 200 AND life_expectancy > 75;

-- all cities in Argentina inside the Buenos Aires district with a pop > 500,000 (returns country name, city name, district, and pop)
SELECT countries.name, cities.name, cities.district, cities.population
FROM countries LEFT JOIN cities ON countries.id=cities.country_id
WHERE countries.name = 'Argentina' AND cities.district = 'Buenos Aires' AND cities.population > 500000;

-- count the number of countries in each region (returns name of region and country count, ordered by country count desc)
SELECT region, COUNT(name) as country_count
FROM countries
GROUP BY region
ORDER BY country_count desc;