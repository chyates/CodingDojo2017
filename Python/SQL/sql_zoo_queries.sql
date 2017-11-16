-- NOBEL LAUREATES
SELECT yr, subject, winner
  FROM nobel
 WHERE yr = 1950

 SELECT winner
  FROM nobel
 WHERE yr = 1962
   AND subject = 'Literature'

SELECT yr, subject
FROM nobel
WHERE winner = 'Albert Einstein'

SELECT winner
FROM nobel
WHERE yr >= 2000 and subject = 'Peace'

SELECT *
FROM nobel
WHERE (yr BETWEEN 1980 AND 1989) AND subject = 'Literature'

SELECT * FROM nobel
 WHERE winner IN ('Theodore Roosevelt',
                  'Jimmy Carter', 'Woodrow Wilson',
                  'Barack Obama')

SELECT winner
FROM nobel
WHERE winner LIKE 'John%'

SELECT yr, subject, winner
FROM nobel
WHERE (yr = 1980 AND subject = 'Physics') OR (yr = 1984 AND subject = 'Chemistry')

SELECT yr, subject, winner
FROM nobel
WHERE yr = 1980 AND (subject NOT LIKE 'Chemistry' AND subject NOT LIKE 'Medicine')

SELECT yr, subject, winner
FROM nobel
WHERE (yr < 1910 AND subject = 'Medicine') OR (yr >= 2004 AND subject = 'Literature')

SELECT yr, subject, winner
FROM nobel
WHERE winner LIKE '%Gr%nberg'

SELECT yr, subject, winner
FROM nobel
WHERE winner LIKE '%O%Neill'

SELECT winner, yr, subject
FROM nobel
WHERE winner LIKE 'Sir%'
ORDER BY yr desc

SELECT winner, subject
  FROM nobel
 WHERE yr=1984
 ORDER BY subject IN ('Physics','Chemistry'), subject, winner