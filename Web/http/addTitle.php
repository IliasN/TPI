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
    </div>
  </div>
</nav>

<div class="container">

  <h2>Administrateur</h2>
  <h3>Ajouter un titre :</h3>

  <form>
  <div class="form-group">
    <label for="exampleInputEmail1">Titre :</label>
    <input type="text" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter email">
  </div>
  <div class="form-group">
    <label for="exampleSelect1">Artiste :</label>
    <select class="form-control" id="exampleSelect1">
      <option>ACDC</option>
      <option>Artiste inconnu</option>
    </select>
  </div>
  <div class="form-group">
    <label for="exampleSelect1">Artiste :</label>
    <select class="form-control" id="exampleSelect1">
      <option>Rock</option>
      <option>Classique</option>
    </select>
  </div>
  <div class="form-group">
    <label for="exampleInputFile">File input</label>
    <input type="file" class="form-control-file" id="exampleInputFile" aria-describedby="fileHelp" accept=".mp3,audio/*">
    <small id="fileHelp" class="form-text text-muted">This is some placeholder block-level help text for the above input. It's a bit lighter and easily wraps to a new line.</small>
  </div>
  <button type="submit" class="btn btn-primary">Submit</button>
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
