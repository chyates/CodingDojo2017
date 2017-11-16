from django.shortcuts import render, redirect
from .models import League, Team, Player

from . import team_maker

def index(request):
	context = {
		"leagues" : League.objects.filter(name__contains="Atlantic"),
		"teams" : Team.objects.order_by("-team_name"),
		"players" : Player.objects.filter(first_name = "Alexander")|Player.objects.filter(first_name="Wyatt"),
	}
	return render(request, "leagues/index.html", context)

def make_data(request):
	team_maker.gen_leagues(10)
	team_maker.gen_teams(50)
	team_maker.gen_players(200)

	return redirect("index")

# 1: All baseball leagues--
	# "leagues": League.objects.filter(sport="Baseball")

# 2: All womens' leagues--
	# "leagues": League.objects.filter(name__contains="Women")

# 3: All leagues where sport is any type of hockey--
	# "leagues": League.objects.filter(sport__contains="Hockey")

# 4: All leagues where sport is something OTHER THAN football--
	# "leagues": League.objects.exclude(sport__contains="Football")

# 5: All leagues that call themselves "conferences"--
	# "leagues" : League.objects.filter(name__contains="conference")

# 6: All leagues in the Atlantic region--
	# "leagues" : League.objects.filter(name__contains="Atlantic")

# 7: All teams based in Dallas--
	# "teams": Team.objects.filter(location="Dallas")

# 8: All teams named the Raptors--
	# "teams": Team.objects.filter(team_name="Raptors")

# 9: All teams whose location includes "City"--
	# "teams": Team.objects.filter(location__contains="City")

# 10: All teams whose names begin with "T"--
	# "teams": Team.objects.filter(team_name__startswith="T")

# 11: All teams, ordered alphabetically by location--
	# "teams" : Team.objects.order_by("location")

# 12: All teams, ordered by team name in reverse alphabetical order--
	# "teams" : Team.objects.order_by("-team_name")

# 13: Every player with the last name "Cooper"--
	# "players" : Player.objects.filter(last_name = "Cooper")

# 14: Every player with the first name "Joshua"--
	# "players" : Player.objects.filter(first_name = "Joshua")

# 15: Every player with the last name "Cooper" EXCEPT those with "Joshua" as the first name--
	# "players" : Player.objects.filter(last_name = "Cooper").exclude(first_name= "Joshua")

# 16: All players with the first name "Alexander" or first name "Wyatt"--
	# "players" : Player.objects.filter(first_name = "Alexander")|Player.objects.filter(first_name="Wyatt")