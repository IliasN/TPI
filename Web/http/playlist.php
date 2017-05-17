<?php
require_once("php/functions.php");
session_start();
CheckConnexion();
//Check that the playlist is from the connected user or that he is admin
$query = $db->prepare("SELECT * FROM playlists WHERE idPlaylist = :idPlaylist AND idUser = :idUser");
$query->execute(array(
  'idUser' => $_SESSION['idUser'],
  'idPlaylist' => htmlentities($_GET['id'])
));
if(count($query->fetchall()) == 0 && $_SESSION['privilegeUser'] == 0){
  header("Location: user.php");
}
//Get the playlist data
$sql = "SELECT namePlaylist,pseudoUser FROM playlists, users WHERE users.idUser = playlists.idUser AND playlists.idPlaylist = :idPlaylist";
$query = $db->prepare($sql);
$query->execute(array(
  'idPlaylist' => htmlentities($_GET['id'])
));
$playlistData = $query->fetchall();
if(count($playlistData) == 0){
  header("Location: user.php");
}
$playlistData = $playlistData[0];
//Get the playlist musics
$sql = 'SELECT * FROM musics,playlists,types,contain,artists WHERE musics.idType = types.idType AND contain.idPlaylist = playlists.idPlaylist AND
contain.idMusic = musics.idMusic AND playlists.idPlaylist = :idPlaylist AND artists.idArtist = musics.idArtist';

$query = $db->prepare($sql);
$query->execute(array(
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
            <li>
              <a href="user.php">Mes playlists</a>
            </li>
          </ul>
          <?php } ?>
        </div>
      </div>
    </nav>

    <div class="container">
      <h2>Playlist de : <?php echo $playlistData['pseudoUser']; ?></h2>
      <h3>Playlist "<?php echo $playlistData['namePlaylist']; ?>" :</h3>
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
