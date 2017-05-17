<!DOCTYPE html>
<html lang="fr">
<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <title>SoundStream</title>
  <link href="css/bootstrap.min.css" rel="stylesheet">
  <link href="css/style.css" rel="stylesheet">
</head>
<body>
  <nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">
    <div class="container">
      <div class="navbar-header">
      </button>
      <a class="navbar-brand" href="index.php">SoundStream</a>
    </div>
    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
    </div>
  </div>
</nav>

<div class="container">

  <h2>Administrateur</h2>
  <h3>Gestion utilisateur "Tom" :</h3>

  <form action="manageUsersphp" method="post">
    <table class="table table-hover">
      <thead>
        <tr>
          <th>Playlist</th>
          <th>Consulter</th>
          <th>Action</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>Tom</td>
          <td><a href="playlist.php">Consulter</a></td>
          <td><input type="checkbox" name="" value=""></td>
        </tr>
        <tr>
          <td>Tom</td>
          <td><a href="playlist.php">Consulter</a></td>
          <td><input type="checkbox" name="" value=""></td>
        </tr>
      </tbody>
    </table>
    <input type="submit" class="btn btn-danger" value="Supprimer les playlists sélectionnés"/>
  </form>

  <form action="manageUsers.php" method="post">
    <input type="hidden" name="userToDel" value="">
    <input type="submit" class="btn btn-danger" value="Supprimer 'Tom'">
  </form>

  <footer>
    <div class="row">
      <div class="col-lg-12">
        <p>&copy; TPI 2017 SoundStream N'hairi Ilias</p>
      </div>
    </div>
  </footer>
</div>



<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
<script src="js/bootstrap.min.js"></script>
</body>
</html>
