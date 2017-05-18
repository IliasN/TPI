<?php
require_once("php/functions.php");
//CHeck the informations to create a new account
if (isset($_POST['pseudo']) && isset($_POST['pass']) && isset($_POST['passConf']) && $_POST['passConf'] == $_POST['pass']) {
  $pseudo = htmlentities($_POST['pseudo']);
  $pass = md5($_POST['passConf']);
  //insert the data in the database
  $query = $db->prepare("INSERT INTO users (pseudoUser,passUser,privilegesUser) VALUES (:pseudo,:pass,0)");
  $query->execute(array(
    'pseudo' => $pseudo,
    'pass' => $pass
  ));

  header("Location: index.php");
}
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
      <a class="navbar-brand" href="index.php">SoundStream</a>
    </div>
    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
    </div>
  </div>
</nav>

<div class="container">

  <form class="form-signin" action="inscription.php" method="post">
          <h2 class="form-signin-heading">Connexion</h2>
          <label for="pseudo" class="sr-only">Pseudo</label>
          <input type="text" id="pseudo" class="form-control" placeholder="Pseudo" name="pseudo" required autofocus>
          <label for="inputPassword" class="sr-only">Mot de passe</label>
          <input type="password" id="inputPassword" class="form-control" placeholder="Mot de passe" name="pass" required>
          <label for="inputPasswordConf" class="sr-only">Mot de passe</label>
          <input type="password" id="inputPasswordConf" class="form-control" placeholder="Confirmer le mot de passe" name="passConf" required>
          <button class="btn btn-lg btn-primary btn-block" type="submit">Connexion</button>
          <div class="text-center">
            <a href="index.php">Inscription</a>
          </div>
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
