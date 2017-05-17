<?php
require_once("php/functions.php");
session_start();
//Check that the playlist is from the connected user
//Get the playlist musics
$query = $db->prepare("SELECT DISTINCT musics.titleMusic,artists.nameArtist,types.labelType,playlists.namePlaylist FROM musics,artists,playlists,contain,types WHERE musics.idArtist = artists.idArtist AND musics.idType = types.idType AND playlists.idUser = :idUser AND contain.idPlaylist = playlists.idPlaylist AND playlists.idPlaylist = :idPlaylist ORDER BY musics.titleMusic;");
$query->execute(array(
  'idUser' => $_SESSION['idUser'],
  'idPlaylist' => htmlentities($_GET['id'])
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
        <a class="navbar-brand" href="index.php">SoundStream</a>
      </div>
      <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
        <?php if(isset($_SESSION['idUser'])) {?>
          <ul class="nav navbar-nav">
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
      <h3>Playlist "<?php echo $data[0]['namePlaylist']; ?>" :</h3>
      <?php if(count($data) > 0){ ?>
        <table class="table table-hover">
          <thead>
            <tr>
              <th>Titre</th>
              <th>Artist</th>
              <th>Type</th>
            </tr>
          </thead>
          <tbody>
            <?php foreach ($data as $music) { ?>
              <tr>
                <td><?php echo $music['titleMusic']; ?></td>
                <td><?php echo $music['nameArtist']; ?></td>
                <td><?php echo $music['labelType']; ?></td>
              </tr>
              <?php } ?>
            </tbody>
          </table>
          <?php }else{ ?>
            <p>Cette playlist est vide.</p>
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
