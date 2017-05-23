<?php
/*
Auteur : N'hairi Ilias
Version : 1.0
Date : 23.05.2017
*/
require_once("php/functions.php");
session_start();
//Check if the user login informations are correct
if (isset($_POST['pseudo']) && isset($_POST['pass'])) {
  $pseudo = htmlentities($_POST['pseudo']);
  $pass = md5($_POST['pass']);
  $query = $db->prepare("SELECT * FROM users WHERE pseudoUser = :pseudo AND passUser = :pass");
  $query->execute(array(
    'pseudo' => $pseudo,
    'pass' => $pass
  ));
  $data = $query->fetchall();

  if (count($data) == 1) {
    //Put the user datas in the session for future verifications
    $_SESSION['pseudoUser'] = $pseudo;
    $_SESSION['idUser'] = $data[0]['idUser'];
    $_SESSION['privilegeUser'] = $data[0]['privilegesUser'];
    //Chech the privileges of the user to redirect him
    if ($_SESSION['privilegeUser'] == 1) {
      header("Location: admin.php");
    }
    else {
      header("Location: user.php");
    }
  }
  else{
    $_SESSION['error'] = "conn";
  }
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

  <form class="form-signin" action="index.php" method="post">
          <h2 class="form-signin-heading">Connexion</h2>
          <label for="pseudo" class="sr-only">Pseudo</label>
          <input type="text" id="pseudo" class="form-control" placeholder="Pseudo" name="pseudo" required autofocus>
          <label for="inputPassword" class="sr-only">Mot de passe</label>
          <input type="password" id="inputPassword" class="form-control" placeholder="Mot de passe" name="pass" required>
          <button class="btn btn-lg btn-primary btn-block" type="submit">Connexion</button>
          <div class="text-center">
            <a href="inscription.php">Inscription</a>
          </div>
        </form>
        <?php
        if(isset($_SESSION['error']) && $_SESSION['error'] == "conn"){ echo "<p>Impossible de se connecter vérifiez vos informations de connexion.</p>"; $_SESSION['error'] = "";}
        if(isset($_SESSION['error']) && $_SESSION['error'] == "newAcc"){ echo "<p>Votre compte a bien été créer.</p>"; $_SESSION['error'] = "";}
        ?>
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
