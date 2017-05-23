<?php
require_once("php/functions.php");
session_start();

// CheckConnexion and admin
CheckConnexion();
CheckAdmin();

//Check if the user exists and get its data
$sql = "SELECT * FROM users WHERE idUser = :id";
$query = $db->prepare($sql);
$query->execute(array(
  'id' => htmlentities($_GET['id'])
));
$user = $query->fetchall();

if(count($user) == 0){
  header("Location: manageUsers.php");
}
$user = $user[0];
//Get all the playlists for the selected user
$sql = "SELECT * FROM playlists WHERE idUser = :id";
$query = $db->prepare($sql);
$query->execute(array(
  'id' => htmlentities($_GET['id'])
));
$playlists = $query->fetchall();
?>
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
      <a class="navbar-brand" href="user.php">SoundStream</a>
    </div>
    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
      <?php if(isset($_SESSION['idUser'])) {?>
      <ul class="nav navbar-nav">
        <li>
          <a href="user.php">Mes playlists</a>
        </li>
        <li>
          <a href="admin.php">Administration</a>
        </li>
        <li>
          <a href="deconnexion.php">Déconnexion</a>
        </li>
      </ul>
      <?php } ?>
    </div>
  </div>
</nav>

<div class="container">

  <h2>Administrateur</h2>
  <h3>Gestion utilisateur "<?php echo $user['pseudoUser']; ?>" :</h3>
<?php if(count($playlists) > 0){ ?>
  <form action="delPlaylists.php" method="post">
    <table class="table table-hover">
      <thead>
        <tr>
          <th>Playlist</th>
          <th>Consulter</th>
          <th>Action</th>
        </tr>
      </thead>
      <tbody>
        <?php foreach ($playlists as $playlist) { ?>
        <tr>
          <td><?php echo $playlist['namePlaylist']; ?></td>
          <td><a href="playlist.php?id=<?php echo $playlist['idPlaylist']; ?>">Consulter</a></td>
          <td><input type="checkbox" name="playlistToDel[]" value="<?php echo $playlist['idPlaylist']; ?>"></td>
        </tr>
        <?php } ?>
      </tbody>
    </table>
    <input type="submit" class="btn btn-danger" value="Supprimer les playlists sélectionnés"/>
  </form>
<?php }else{ ?>
  <p>Aucune playlist.</p>
  <?php } ?>
  <form action="delUsers.php" method="post">
    <input type="hidden" name="usersToDel[]" value="<?php echo $user['idUser']; ?>">
    <input type="submit" class="btn btn-danger" value="Supprimer '<?php echo $user['pseudoUser']; ?>'">
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
