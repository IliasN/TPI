-- phpMyAdmin SQL Dump
-- version 4.7.0
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1
-- Généré le :  mer. 10 mai 2017 à 15:53
-- Version du serveur :  5.7.17
-- Version de PHP :  5.6.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `tpi`
--

-- --------------------------------------------------------

--
-- Structure de la table `artists`
--

CREATE TABLE `artists` (
  `idArtist` int(11) NOT NULL,
  `nameArtist` varchar(40) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `artists`
--

INSERT INTO `artists` (`idArtist`, `nameArtist`) VALUES
(1, 'Artiste inconnu');

-- --------------------------------------------------------

--
-- Structure de la table `contain`
--

CREATE TABLE `contain` (
  `idPlaylist` int(11) NOT NULL,
  `idMusic` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `contain`
--

INSERT INTO `contain` (`idPlaylist`, `idMusic`) VALUES
(1, 2),
(1, 3);

-- --------------------------------------------------------

--
-- Structure de la table `favorites`
--

CREATE TABLE `favorites` (
  `idUser` int(11) NOT NULL,
  `idMusic` int(11) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `favorites`
--

INSERT INTO `favorites` (`idUser`, `idMusic`) VALUES
(1, 2),
(2, 1);

-- --------------------------------------------------------

--
-- Structure de la table `musics`
--

CREATE TABLE `musics` (
  `idMusic` int(11) NOT NULL,
  `titleMusic` varchar(25) DEFAULT NULL,
  `idType` int(11) NOT NULL,
  `idArtist` int(11) NOT NULL,
  `fileName` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `musics`
--

INSERT INTO `musics` (`idMusic`, `titleMusic`, `idType`, `idArtist`, `fileName`) VALUES
(1, 'Tendresse', 2, 1, 'Tendresse.mp3'),
(2, 'Gestation', 2, 1, 'Gestation.mp3'),
(3, 'Forest', 2, 1, 'Forest.mp3');

-- --------------------------------------------------------

--
-- Structure de la table `playlists`
--

CREATE TABLE `playlists` (
  `idPlaylist` int(11) NOT NULL,
  `namePlaylist` varchar(25) NOT NULL,
  `idUser` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `playlists`
--

INSERT INTO `playlists` (`idPlaylist`, `namePlaylist`, `idUser`) VALUES
(1, 'Démonstration', 2);

-- --------------------------------------------------------

--
-- Structure de la table `types`
--

CREATE TABLE `types` (
  `idType` int(11) NOT NULL,
  `labelType` varchar(40) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `types`
--

INSERT INTO `types` (`idType`, `labelType`) VALUES
(1, 'Reggea'),
(2, 'Classique');

-- --------------------------------------------------------

--
-- Structure de la table `users`
--

CREATE TABLE `users` (
  `idUser` int(11) NOT NULL,
  `pseudoUser` varchar(30) NOT NULL,
  `passUser` longtext NOT NULL,
  `privilegesUser` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `users`
--

INSERT INTO `users` (`idUser`, `pseudoUser`, `passUser`, `privilegesUser`) VALUES
(1, 'Admin', '0ce3266d4eb71ad50f7a90aee6d21dcd', 1),
(2, 'Ilias', '0ce3266d4eb71ad50f7a90aee6d21dcd', 0),
(5, 'Test', '0ce3266d4eb71ad50f7a90aee6d21dcd', 0),
(6, 'Dylan', '0ce3266d4eb71ad50f7a90aee6d21dcd', 0),
(7, 'David', '0ce3266d4eb71ad50f7a90aee6d21dcd', 0);

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `artists`
--
ALTER TABLE `artists`
  ADD PRIMARY KEY (`idArtist`);

--
-- Index pour la table `contain`
--
ALTER TABLE `contain`
  ADD PRIMARY KEY (`idPlaylist`,`idMusic`),
  ADD KEY `FK_contain_idMusic` (`idMusic`);

--
-- Index pour la table `favorites`
--
ALTER TABLE `favorites`
  ADD PRIMARY KEY (`idUser`,`idMusic`);

--
-- Index pour la table `musics`
--
ALTER TABLE `musics`
  ADD PRIMARY KEY (`idMusic`),
  ADD KEY `FK_musics_idType` (`idType`),
  ADD KEY `FK_musics_idArtist` (`idArtist`);

--
-- Index pour la table `playlists`
--
ALTER TABLE `playlists`
  ADD PRIMARY KEY (`idPlaylist`),
  ADD KEY `FK_playlists_idUser` (`idUser`);

--
-- Index pour la table `types`
--
ALTER TABLE `types`
  ADD PRIMARY KEY (`idType`);

--
-- Index pour la table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`idUser`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `artists`
--
ALTER TABLE `artists`
  MODIFY `idArtist` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT pour la table `musics`
--
ALTER TABLE `musics`
  MODIFY `idMusic` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT pour la table `playlists`
--
ALTER TABLE `playlists`
  MODIFY `idPlaylist` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT pour la table `types`
--
ALTER TABLE `types`
  MODIFY `idType` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT pour la table `users`
--
ALTER TABLE `users`
  MODIFY `idUser` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `contain`
--
ALTER TABLE `contain`
  ADD CONSTRAINT `FK_contain_idMusic` FOREIGN KEY (`idMusic`) REFERENCES `musics` (`idMusic`)ON DELETE CASCADE,
  ADD CONSTRAINT `FK_contain_idPlaylist` FOREIGN KEY (`idPlaylist`) REFERENCES `playlists` (`idPlaylist`)ON DELETE CASCADE;

--
-- Contraintes pour la table `musics`
--
ALTER TABLE `musics`
  ADD CONSTRAINT `FK_musics_idArtist` FOREIGN KEY (`idArtist`) REFERENCES `artists` (`idArtist`),
  ADD CONSTRAINT `FK_musics_idType` FOREIGN KEY (`idType`) REFERENCES `types` (`idType`);

--
-- Contraintes pour la table `playlists`
--
ALTER TABLE `playlists`
  ADD CONSTRAINT `FK_playlists_idUser` FOREIGN KEY (`idUser`) REFERENCES `users` (`idUser`)ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
