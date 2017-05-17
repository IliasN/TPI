<?php
require_once("php/functions.php");
session_start();

//Get the users data
$sql = "SELECT * FROM users";
$query = $db->prepare($sql);
$query->execute();
$users = $query->fetchall();
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

  <h2>Administrateur</h2>

  <form class="" action="manageUsers.php" method="post">
    <table class="table table-hover">
      <thead>
        <tr>
          <th>Utilisateur</th>
          <th>Playlists</th>
          <th>Action</th>
        </tr>
      </thead>
      <tbody>
        <?php foreach ($users as $user) {?>
        <tr>
          <td><?php echo $user['pseudoUser']; ?></td>
          <td><a href="manageUser.php?id=<?php echo $user['idUser']; ?>">Consulter</a></td>
          <td><input type="checkbox" name="usersToDel[]" value="<?php echo $user['idUser']; ?>"></td>
        </tr>
        <?php } ?>
      </tbody>
    </table>
    <input type="submit" class="btn btn-danger" value="Supprimer les utilisateur sélectionnés"/>
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
