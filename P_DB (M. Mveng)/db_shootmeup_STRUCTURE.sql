-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Hôte : db:3306
-- Généré le : lun. 28 oct. 2024 à 09:34
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

-- --------------------------------------------------------

--
-- Structure de la table `avoir`
--

CREATE TABLE `avoir` (
  `ennemi_id` int NOT NULL,
  `partie_id` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Structure de la table `contenir`
--

CREATE TABLE `contenir` (
  `obstacle_id` int NOT NULL,
  `partie_id` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Structure de la table `jouer`
--

CREATE TABLE `jouer` (
  `joueur_id` int NOT NULL,
  `partie_id` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Structure de la table `posseder`
--

CREATE TABLE `posseder` (
  `joueur_id` int NOT NULL,
  `score_id` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Structure de la table `t_ennemi`
--

CREATE TABLE `t_ennemi` (
  `ennemi_id` int NOT NULL,
  `forme` varchar(20) NOT NULL,
  `positionx` int NOT NULL,
  `positiony` int NOT NULL,
  `nbvie` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Structure de la table `t_joueur`
--

CREATE TABLE `t_joueur` (
  `joueur_id` int NOT NULL,
  `nom` varchar(15) NOT NULL,
  `niveau_id` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Structure de la table `t_missile`
--

CREATE TABLE `t_missile` (
  `missile_id` int NOT NULL,
  `positionx` int NOT NULL,
  `positiony` int NOT NULL,
  `vitesse` int NOT NULL,
  `etat` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Structure de la table `t_niveau`
--

CREATE TABLE `t_niveau` (
  `niveau_id` int NOT NULL,
  `nivNom` varchar(20) NOT NULL,
  `nivFacteurdifficulte` decimal(15,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Structure de la table `t_obstacle`
--

CREATE TABLE `t_obstacle` (
  `obstacle_id` int NOT NULL,
  `positionx` int NOT NULL,
  `positiony` int NOT NULL,
  `nbvie` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Structure de la table `t_partie`
--

CREATE TABLE `t_partie` (
  `partie_id` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Structure de la table `t_score`
--

CREATE TABLE `t_score` (
  `score_id` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Structure de la table `t_vaisseau`
--

CREATE TABLE `t_vaisseau` (
  `vaisseau_id` int NOT NULL,
  `vitesse` int NOT NULL,
  `forme` varchar(15) NOT NULL,
  `nbvie` int NOT NULL,
  `missile_id` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- --------------------------------------------------------

--
-- Structure de la table `utiliser`
--

CREATE TABLE `utiliser` (
  `vaisseau_id` int NOT NULL,
  `partie_id` int NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- Index pour les tables déchargées
--

--
-- Index pour la table `avoir`
--
ALTER TABLE `avoir`
  ADD PRIMARY KEY (`ennemi_id`,`partie_id`),
  ADD KEY `partie_id` (`partie_id`);

--
-- Index pour la table `contenir`
--
ALTER TABLE `contenir`
  ADD PRIMARY KEY (`obstacle_id`,`partie_id`),
  ADD KEY `partie_id` (`partie_id`);

--
-- Index pour la table `jouer`
--
ALTER TABLE `jouer`
  ADD PRIMARY KEY (`joueur_id`,`partie_id`),
  ADD KEY `partie_id` (`partie_id`);

--
-- Index pour la table `posseder`
--
ALTER TABLE `posseder`
  ADD PRIMARY KEY (`joueur_id`,`score_id`),
  ADD KEY `score_id` (`score_id`);

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
  ADD KEY `niveau_id` (`niveau_id`);

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
  ADD KEY `missile_id` (`missile_id`);

--
-- Index pour la table `utiliser`
--
ALTER TABLE `utiliser`
  ADD PRIMARY KEY (`vaisseau_id`,`partie_id`),
  ADD KEY `partie_id` (`partie_id`);

--
-- AUTO_INCREMENT pour les tables déchargées
--

--
-- AUTO_INCREMENT pour la table `t_ennemi`
--
ALTER TABLE `t_ennemi`
  MODIFY `ennemi_id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `t_joueur`
--
ALTER TABLE `t_joueur`
  MODIFY `joueur_id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `t_missile`
--
ALTER TABLE `t_missile`
  MODIFY `missile_id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `t_niveau`
--
ALTER TABLE `t_niveau`
  MODIFY `niveau_id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `t_obstacle`
--
ALTER TABLE `t_obstacle`
  MODIFY `obstacle_id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `t_partie`
--
ALTER TABLE `t_partie`
  MODIFY `partie_id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `t_score`
--
ALTER TABLE `t_score`
  MODIFY `score_id` int NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT pour la table `t_vaisseau`
--
ALTER TABLE `t_vaisseau`
  MODIFY `vaisseau_id` int NOT NULL AUTO_INCREMENT;

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `avoir`
--
ALTER TABLE `avoir`
  ADD CONSTRAINT `avoir_ibfk_1` FOREIGN KEY (`ennemi_id`) REFERENCES `t_ennemi` (`ennemi_id`),
  ADD CONSTRAINT `avoir_ibfk_2` FOREIGN KEY (`partie_id`) REFERENCES `t_partie` (`partie_id`);

--
-- Contraintes pour la table `contenir`
--
ALTER TABLE `contenir`
  ADD CONSTRAINT `contenir_ibfk_1` FOREIGN KEY (`obstacle_id`) REFERENCES `t_obstacle` (`obstacle_id`),
  ADD CONSTRAINT `contenir_ibfk_2` FOREIGN KEY (`partie_id`) REFERENCES `t_partie` (`partie_id`);

--
-- Contraintes pour la table `jouer`
--
ALTER TABLE `jouer`
  ADD CONSTRAINT `jouer_ibfk_1` FOREIGN KEY (`joueur_id`) REFERENCES `t_joueur` (`joueur_id`),
  ADD CONSTRAINT `jouer_ibfk_2` FOREIGN KEY (`partie_id`) REFERENCES `t_partie` (`partie_id`);

--
-- Contraintes pour la table `posseder`
--
ALTER TABLE `posseder`
  ADD CONSTRAINT `posseder_ibfk_1` FOREIGN KEY (`joueur_id`) REFERENCES `t_joueur` (`joueur_id`),
  ADD CONSTRAINT `posseder_ibfk_2` FOREIGN KEY (`score_id`) REFERENCES `t_score` (`score_id`);

--
-- Contraintes pour la table `t_joueur`
--
ALTER TABLE `t_joueur`
  ADD CONSTRAINT `t_joueur_ibfk_1` FOREIGN KEY (`niveau_id`) REFERENCES `t_niveau` (`niveau_id`);

--
-- Contraintes pour la table `t_vaisseau`
--
ALTER TABLE `t_vaisseau`
  ADD CONSTRAINT `t_vaisseau_ibfk_1` FOREIGN KEY (`missile_id`) REFERENCES `t_missile` (`missile_id`);

--
-- Contraintes pour la table `utiliser`
--
ALTER TABLE `utiliser`
  ADD CONSTRAINT `utiliser_ibfk_1` FOREIGN KEY (`vaisseau_id`) REFERENCES `t_vaisseau` (`vaisseau_id`),
  ADD CONSTRAINT `utiliser_ibfk_2` FOREIGN KEY (`partie_id`) REFERENCES `t_partie` (`partie_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
