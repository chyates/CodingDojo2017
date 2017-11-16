from django.db.models import Count

# ...all teams in the Atlantic Soccer Conference
def all_atlantic_soccer_teams():
    for team in Team.objects.filter(league__name__contains="Atlantic Soccer"):
        print team.team_name

# ...all (current) players on the Boston Penguins
def all_curr_players_Penguins():
    for player in Player.objects.filter(curr_team__team_name="Penguins", curr_team__location="Boston"):
        print player.first_name, player.last_name

# ...all (current) players in the International Collegiate Baseball Conference
def all_curr_players_ICBA():
    for player in Player.objects.filter(curr_team__league__name="International Collegiate Baseball Conference"):
        print player.first_name, player.last_name

# ...all (current) players in the American Conference of Amateur Football with last name "Lopez"
def all_curr_players_ACAF_Lopez():
    for player in Player.objects.filter(curr_team__league__name = "American Conference of Amateur Football", last_name = "Lopez"):
        print player.first_name, player.last_name

# ...all football players
def all_football_players():
    for player in Player.objects.filter(curr_team__league__sport="Football"):
        print player.first_name, player.last_name

# ...all teams with a (current) player named "Sophia"
def all_teams_curr_sophia():
    for team in Team.objects.filter(curr_players__first_name="Sophia"):
        print team.location, team.team_name

# ...all leagues with a (current) player named "Sophia"
def all_leagues_curr_Sophia():
    for league in League.objects.filter(teams__curr_players__first_name="Sophia"):
        print league.name

# ...everyone with the last name "Flores" who DOESN'T (currently) play for the Washington Roughriders
def player_no_wash_rough():
    for player in Player.objects.filter(last_name="Flores").exclude(curr_team__team_name="Roughriders"):
        print player.first_name, player.last_name

# ...all teams, past and present, that Samuel Evans has played with
def all_sam_evans():
    for team in Team.objects.filter(all_players__first_name="Samuel", all_players__last_name="Evans"):
        print team.team_name, team.location

# ...all players, past and present, with the Manitoba Tiger-Cats
def all_players_tiger_cats():
    for player in Player.objects.filter(all_teams__team_name="Tiger-Cats", all_teams__location="Manitoba"):
        print player.first_name, player.last_name

# ...all players who were formerly (but aren't currently) with the Wichita Vikings
def no_curr_players_vikings():
    for player in Player.objects.filter(all_teams__team_name="Vikings", all_teams__location="Wichita").exclude(curr_team__team_name="Vikings"):
        print player.first_name, player.last_name

# ...every team that Jacob Gray played for before he joined the Oregon Colts
def prev_teams_JG():
    for team in Team.objects.filter(all_players__first_name="Jacob", all_players__last_name="Gray").exclude(team_name="Colts", location="Oregon"):
        print team.team_name

# ...everyone named "Joshua" who has ever played in the Atlantic Federation of Amateur Baseball Players
def any_josh_AFABP():
    for player in Player.objects.filter(first_name="Joshua", all_teams__league__name="Atlantic Federation of Amateur Baseball Players"):
        print player.first_name, player.last_name

# ...all teams that have had 12 or more players, past and present. (HINT: Look up the Django annotate function.)
def all_teams_count():
    for team in Team.objects.annotate(player_count=Count('all_players')).filter(player_count=12):
        print team.team_name

# ...all players and count of teams played for, sorted by the number of teams they've played for
def all_players_num_teams():
    for player in Player.objects.annotate(team_count=Count('all_teams')).order_by("-team_count"):
        print player.first_name, player.last_name, player.team_count