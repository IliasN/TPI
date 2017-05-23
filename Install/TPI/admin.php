<?php
require_once("php/functions.php");
session_start();

// CheckConnexion and admin
CheckConnexion();
CheckAdmin();
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

  <h2>Administration</h2>
  <a href="manageUsers.php">Gérer les utilisateurs</a>
  <br>
  <a href="addTitle.php">Ajouter un titre</a>

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
