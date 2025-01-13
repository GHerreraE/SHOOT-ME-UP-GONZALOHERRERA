-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Hôte : db:3306
-- Généré le : lun. 13 jan. 2025 à 21:51
-- Version du serveur : 8.0.30
-- Version de PHP : 8.0.27

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `db_shootmeup`
--
CREATE DATABASE db_shootmeup;
USE db_shootmeup;

-- --------------------------------------------------------

--
-- Structure de la table `t_avoir`
--

CREATE TABLE `t_avoir` (
  `fk_ennemi_id` INT NOT NULL,
  `fk_partie_id` INT NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `t_avoir`
--

INSERT INTO `t_avoir` (`fk_ennemi_id`, `fk_partie_id`) VALUES
(1, 1),
(2, 1),
(3, 1),
(4, 1),
(5, 1),
(6, 1),
(7, 1),
(8, 1),
(9, 1),
(10, 1),
(11, 1),
(12, 1),
(1, 2),
(2, 2),
(3, 2),
(4, 2),
(5, 2),
(6, 2),
(7, 2),
(8, 2),
(9, 2),
(10, 2),
(11, 2),
(12, 2);

-- --------------------------------------------------------

--
-- Structure de la table `t_contenir`
--

CREATE TABLE `t_contenir` (
  `fk_obstacle_id` INT NOT NULL,
  `fk_partie_id` INT NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `t_contenir`
--

INSERT INTO `t_contenir` (`fk_obstacle_id`, `fk_partie_id`) VALUES
(1, 1),
(2, 1),
(3, 1),
(4, 1),
(5, 1),
(1, 2),
(2, 2),
(3, 2),
(4, 2),
(5, 2);

-- --------------------------------------------------------

--
-- Structure de la table `t_jouer`
--

CREATE TABLE `t_jouer` (
  `joueur_id` INT NOT NULL,
  `partie_id` INT NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `t_jouer`
--

INSERT INTO `t_jouer` (`joueur_id`, `partie_id`) VALUES
(1, 1),
(2, 1),
(1, 2),
(2, 2),
(1, 3),
(2, 3),
(1, 4),
(2, 4),
(1, 5),
(2, 5);

-- --------------------------------------------------------

--
-- Structure de la table `t_posseder`
--

CREATE TABLE `t_posseder` (
  `fk_joueur_id` INT NOT NULL,
  `fk_score_id` INT NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `t_posseder`
--

INSERT INTO `t_posseder` (`fk_joueur_id`, `fk_score_id`) VALUES
(1, 1),
(1, 2),
(2, 3),
(2, 4),
(1, 5),
(2, 6),
(1, 7),
(2, 8),
(1, 9),
(2, 10);

-- --------------------------------------------------------

--
-- Structure de la table `t_ennemi`
--

CREATE TABLE `t_ennemi` (
  `ennemi_id` INT NOT NULL,
  `forme` VARCHAR(20) NOT NULL,
  `positionx` INT NOT NULL,
  `positiony` INT NOT NULL,
  `nbvie` VARCHAR(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `t_ennemi`
--

INSERT INTO `t_ennemi` (`ennemi_id`, `forme`, `positionx`, `positiony`, `nbvie`) VALUES
(1, 'Ennemi1', 100, 50, '3'),
(2, 'Ennemi2', 200, 50, '3'),
(3, 'Ennemi3', 300, 50, '3'),
(4, 'Ennemi4', 400, 50, '3'),
(5, 'Ennemi5', 500, 50, '3'),
(6, 'Ennemi6', 600, 50, '3'),
(7, 'Ennemi7', 700, 50, '3'),
(8, 'Ennemi8', 100, 100, '3'),
(9, 'Ennemi9', 200, 100, '3'),
(10, 'Ennemi10', 300, 100, '3'),
(11, 'Ennemi11', 400, 100, '3'),
(12, 'Ennemi12', 500, 100, '3');

-- --------------------------------------------------------

--
-- Structure de la table `t_joueur`
--

CREATE TABLE `t_joueur` (
  `joueur_id` INT NOT NULL,
  `nom` VARCHAR(15) NOT NULL,
  `fk_niveau_id` INT NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `t_joueur`
--

INSERT INTO `t_joueur` (`joueur_id`, `nom`, `fk_niveau_id`) VALUES
(1, 'Thomas Gonzalez', 1),
(2, 'Jean-Michel Gui', 2);

-- --------------------------------------------------------

--
-- Structure de la table `t_missile`
--

CREATE TABLE `t_missile` (
  `missile_id` INT NOT NULL,
  `positionx` INT NOT NULL,
  `positiony` INT NOT NULL,
  `vitesse` INT NOT NULL,
  `etat` VARCHAR(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `t_missile`
--

INSERT INTO `t_missile` (`missile_id`, `positionx`, `positiony`, `vitesse`, `etat`) VALUES
(1, 150, 300, 10, 'actif'),
(2, 250, 300, 10, 'actif'),
(3, 350, 300, 10, 'actif'),
(4, 450, 300, 10, 'actif'),
(5, 550, 300, 10, 'actif'),
(6, 650, 300, 10, 'actif'),
(7, 750, 300, 10, 'actif'),
(8, 850, 300, 10, 'actif'),
(9, 950, 300, 10, 'actif'),
(10, 1050, 300, 10, 'actif'),
(11, 1150, 300, 10, 'actif'),
(12, 1250, 300, 10, 'actif');

-- --------------------------------------------------------

--
-- Structure de la table `t_niveau`
--

CREATE TABLE `t_niveau` (
  `niveau_id` INT NOT NULL,
  `nivNom` VARCHAR(20) NOT NULL,
  `nivFacteurdifficulte` DECIMAL(15,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `t_niveau`
--

INSERT INTO `t_niveau` (`niveau_id`, `nivNom`, `nivFacteurdifficulte`) VALUES
(1, 'Niveau Facile', '1.00'),
(2, 'Niveau Moyen', '1.50'),
(3, 'Niveau Difficile', '2.00');

-- --------------------------------------------------------

--
-- Structure de la table `t_obstacle`
--

CREATE TABLE `t_obstacle` (
  `obstacle_id` INT NOT NULL,
  `positionx` INT NOT NULL,
  `positiony` INT NOT NULL,
  `nbvie` INT NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `t_obstacle`
--

INSERT INTO `t_obstacle` (`obstacle_id`, `positionx`, `positiony`, `nbvie`) VALUES
(1, 150, 100, 3),
(2, 350, 100, 3),
(3, 550, 100, 3),
(4, 750, 100, 3),
(5, 950, 100, 3);

-- --------------------------------------------------------

--
-- Structure de la table `t_partie`
--

CREATE TABLE `t_partie` (
  `partie_id` INT NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `t_partie`
--

INSERT INTO `t_partie` (`partie_id`) VALUES
(1),
(2),
(3),
(4),
(5),
(6),
(7),
(8),
(9),
(10);

-- --------------------------------------------------------

--
-- Structure de la table `t_score`
--

CREATE TABLE `t_score` (
  `score_id` INT NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `t_score`
-- 

INSERT INTO `t_score` (`score_id`) VALUES
(1),
(2),
(3),
(4),
(5),
(6),
(7),
(8),
(9),
(10);

-- --------------------------------------------------------

--
-- Structure de la table `t_vaisseau`
--

CREATE TABLE `t_vaisseau` (
  `vaisseau_id` INT NOT NULL,
  `vitesse` INT NOT NULL,
  `forme` VARCHAR(15) NOT NULL,
  `nbvie` INT NOT NULL,
  `fk_missile_id` INT NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `t_vaisseau`
--

INSERT INTO `t_vaisseau` (`vaisseau_id`, `vitesse`, `forme`, `nbvie`, `fk_missile_id`) VALUES
(1, 5, 'Vaisseau1', 3, 1),
(2, 5, 'Vaisseau2', 3, 2),
(3, 5, 'Vaisseau3', 3, 3),
(4, 5, 'Vaisseau4', 3, 4),
(5, 5, 'Vaisseau5', 3, 5);

-- --------------------------------------------------------

--
-- Structure de la table `t_utiliser`
--

CREATE TABLE `t_utiliser` (
  `fk_vaisseau_id` INT NOT NULL,
  `fk_partie_id` INT NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Déchargement des données de la table `t_utiliser`
--

INSERT INTO `t_utiliser` (`fk_vaisseau_id`, `fk_partie_id`) VALUES
(1, 1),
(2, 1),
(1, 2),
(2, 2),
(1, 3),
(2, 3),
(1, 4),
(2, 4),
(1, 5),
(2, 5);

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `t_avoir`
--
ALTER TABLE `t_avoir`
  ADD PRIMARY KEY (`fk_ennemi_id`,`fk_partie_id`),
  ADD KEY `fk_partie_id` (`fk_partie_id`);

--
-- Index pour la table `t_contenir`
--
ALTER TABLE `t_contenir`
  ADD PRIMARY KEY (`fk_obstacle_id`,`fk_partie_id`),
  ADD KEY `fk_partie_id` (`fk_partie_id`);

--
-- Index pour la table `t_jouer`
--
ALTER TABLE `t_jouer`
  ADD PRIMARY KEY (`joueur_id`,`partie_id`),
  ADD KEY `partie_id` (`partie_id`);

--
-- Index pour la table `t_posseder`
--
ALTER TABLE `t_posseder`
  ADD PRIMARY KEY (`fk_joueur_id`,`fk_score_id`),
  ADD KEY `fk_score_id` (`fk_score_id`);

--
-- Index pour la table `t_ennemi`
--
ALTER TABLE `t_ennemi`
  ADD PRIMARY KEY (`ennemi_id`);

--
-- Index pour la table `t_joueur`
--
ALTER TABLE `t_joueur`
  ADD PRIMARY KEY (`joueur_id`),
  ADD KEY `fk_niveau_id` (`fk_niveau_id`);

--
-- Index pour la table `t_missile`
--
ALTER TABLE `t_missile`
  ADD PRIMARY KEY (`missile_id`);

--
-- Index pour la table `t_niveau`
--
ALTER TABLE `t_niveau`
  ADD PRIMARY KEY (`niveau_id`);

--
-- Index pour la table `t_obstacle`
--
ALTER TABLE `t_obstacle`
  ADD PRIMARY KEY (`obstacle_id`);

--
-- Index pour la table `t_partie`
--
ALTER TABLE `t_partie`
  ADD PRIMARY KEY (`partie_id`);

--
-- Index pour la table `t_score`
--
ALTER TABLE `t_score`
  ADD PRIMARY KEY (`score_id`);

--
-- Index pour la table `t_vaisseau`
--
ALTER TABLE `t_vaisseau`
  ADD PRIMARY KEY (`vaisseau_id`),
  ADD KEY `fk_missile_id` (`fk_missile_id`);

--
-- Index pour la table `t_utiliser`
--
ALTER TABLE `t_utiliser`
  ADD PRIMARY KEY (`fk_vaisseau_id`,`fk_partie_id`),
  ADD KEY `fk_partie_id` (`fk_partie_id`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `t_ennemi`
--
ALTER TABLE `t_ennemi`
  MODIFY `ennemi_id` INT NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT pour la table `t_joueur`
--
ALTER TABLE `t_joueur`
  MODIFY `joueur_id` INT NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT pour la table `t_missile`
--
ALTER TABLE `t_missile`
  MODIFY `missile_id` INT NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT pour la table `t_niveau`
--
ALTER TABLE `t_niveau`
  MODIFY `niveau_id` INT NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT pour la table `t_obstacle`
--
ALTER TABLE `t_obstacle`
  MODIFY `obstacle_id` INT NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT pour la table `t_partie`
--
ALTER TABLE `t_partie`
  MODIFY `partie_id` INT NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT pour la table `t_score`
--
-- Ajusté à 11 puisque le plus grand score_id conservé est 10
ALTER TABLE `t_score`
  MODIFY `score_id` INT NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT pour la table `t_vaisseau`
--
ALTER TABLE `t_vaisseau`
  MODIFY `vaisseau_id` INT NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `t_avoir`
--
ALTER TABLE `t_avoir`
  ADD CONSTRAINT `avoir_ibfk_1` FOREIGN KEY (`fk_ennemi_id`) REFERENCES `t_ennemi`(`ennemi_id`),
  ADD CONSTRAINT `avoir_ibfk_2` FOREIGN KEY (`fk_partie_id`) REFERENCES `t_partie`(`partie_id`);

--
-- Contraintes pour la table `t_contenir`
--
ALTER TABLE `t_contenir`
  ADD CONSTRAINT `contenir_ibfk_1` FOREIGN KEY (`fk_obstacle_id`) REFERENCES `t_obstacle`(`obstacle_id`),
  ADD CONSTRAINT `contenir_ibfk_2` FOREIGN KEY (`fk_partie_id`) REFERENCES `t_partie`(`partie_id`);

--
-- Contraintes pour la table `t_jouer`
--
ALTER TABLE `t_jouer`
  ADD CONSTRAINT `jouer_ibfk_1` FOREIGN KEY (`joueur_id`) REFERENCES `t_joueur`(`joueur_id`),
  ADD CONSTRAINT `jouer_ibfk_2` FOREIGN KEY (`partie_id`) REFERENCES `t_partie`(`partie_id`);

--
-- Contraintes pour la table `t_posseder`
--
ALTER TABLE `t_posseder`
  ADD CONSTRAINT `posseder_ibfk_1` FOREIGN KEY (`fk_joueur_id`) REFERENCES `t_joueur`(`joueur_id`),
  ADD CONSTRAINT `posseder_ibfk_2` FOREIGN KEY (`fk_score_id`) REFERENCES `t_score`(`score_id`);

--
-- Contraintes pour la table `t_joueur`
--
ALTER TABLE `t_joueur`
  ADD CONSTRAINT `t_joueur_ibfk_1` FOREIGN KEY (`fk_niveau_id`) REFERENCES `t_niveau`(`niveau_id`);

--
-- Contraintes pour la table `t_vaisseau`
--
ALTER TABLE `t_vaisseau`
  ADD CONSTRAINT `t_vaisseau_ibfk_1` FOREIGN KEY (`fk_missile_id`) REFERENCES `t_missile`(`missile_id`);

--
-- Contraintes pour la table `t_utiliser`
--
ALTER TABLE `t_utiliser`
  ADD CONSTRAINT `utiliser_ibfk_1` FOREIGN KEY (`fk_vaisseau_id`) REFERENCES `t_vaisseau`(`vaisseau_id`),
  ADD CONSTRAINT `utiliser_ibfk_2` FOREIGN KEY (`fk_partie_id`) REFERENCES `t_partie`(`partie_id`);

COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
