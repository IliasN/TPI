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
      <a class="navbar-brand" href="#">SoundStream</a>
    </div>
    <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
    </div>
  </div>
</nav>

<div class="container">

  <form class="form-signin" action="test.php" method="post">
          <h2 class="form-signin-heading">Connexion</h2>
          <label for="inputEmail" class="sr-only">Pseudo</label>
          <input type="text" id="inputEmail" class="form-control" placeholder="Pseudo" required autofocus>
          <label for="inputPassword" class="sr-only">Mot de passe</label>
          <input type="password" id="inputPassword" class="form-control" placeholder="Mot de passe" required>
          <label for="inputPasswordConf" class="sr-only">Mot de passe</label>
          <input type="password" id="inputPasswordConf" class="form-control" placeholder="Confirmer le mot de passe" required>
          <button class="btn btn-lg btn-primary btn-block" type="submit">Connexion</button>
          <div class="text-center">
            <a href="index.php">Connexion</a>
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
