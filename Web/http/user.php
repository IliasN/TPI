<?php
/*
Author : N'hairi Ilias
Version : 1.0
Date : 23.05.2017
*/
require_once("php/functions.php");
session_start();
//Check if user connected
CheckConnexion();

//Get the playlists from a user
$query = $db->prepare("SELECT * FROM playlists WHERE idUser = :id");
$query->execute(array(
  'id' => $_SESSION['idUser']
));
$data = $query->fetchall();

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
        <?php   if ($_SESSION['privilegeUser'] == 1) { ?>
        <li>
          <a href="admin.php">Administration</a>
        </li>
        <?php } ?>
        <li>
          <a href="deconnexion.php">Déconnexion</a>
        </li>
      </ul>
      <?php } ?>
    </div>
  </div>
</nav>

<div class="container">
  <h2><?php echo $_SESSION['pseudoUser']; ?></h2>
  <h3>Vos playlists :</h3>
  <?php if(count($data) > 0) { ?>
  <div class="list-group">
    <?php foreach ($data as $playlist) { ?>
    <a href="playlist.php?id=<?php echo $playlist['idPlaylist']; ?>" class="list-group-item"><?php echo $playlist['namePlaylist']; ?></a>
    <?php } ?>
  </div>
  <?php }
  else{ ?>
    <p>Vous n'avez pas de playlists.</p>
    <?php } ?>

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
