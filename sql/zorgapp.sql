SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

CREATE DATABASE IF NOT EXISTS `zorgapp` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `zorgapp`;

CREATE TABLE `drug` (
  `id` int(11) NOT NULL,
  `name` varchar(24) NOT NULL,
  `description` text NOT NULL,
  `type` varchar(24) NOT NULL,
  `dosage` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

TRUNCATE TABLE `drug`;
INSERT INTO `drug` VALUES(1, 'paracetamol', 'paracetamol description', 'pill', 'paracetamol dosage ');
INSERT INTO `drug` VALUES(2, 'aspirine', 'aspirine discription', 'powder', 'aspirine dosage');
INSERT INTO `drug` VALUES(3, 'vaseline', 'vaseline desc', 'gel', 'vaseline dosage');

CREATE TABLE `drugprescription` (
  `drugId` int(11) NOT NULL,
  `profileId` int(11) NOT NULL,
  `startDate` date NOT NULL,
  `endDate` date NOT NULL,
  `intakeTime` time NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

TRUNCATE TABLE `drugprescription`;
INSERT INTO `drugprescription` VALUES(1, 1, '2020-02-26', '2020-03-06', '19:00:00');
INSERT INTO `drugprescription` VALUES(2, 1, '2020-02-27', '2020-03-06', '19:00:00');
INSERT INTO `drugprescription` VALUES(2, 2, '2020-02-27', '2020-02-28', '12:00:00');
INSERT INTO `drugprescription` VALUES(2, 3, '2020-03-16', '2020-03-18', '07:19:00');
INSERT INTO `drugprescription` VALUES(3, 3, '2020-03-16', '2020-03-17', '07:00:00');

CREATE TABLE `profile` (
  `id` int(9) NOT NULL,
  `name` varchar(24) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `surname` varchar(24) CHARACTER SET utf8 COLLATE utf8_croatian_ci NOT NULL,
  `age` int(3) NOT NULL,
  `weight` double(5,2) NOT NULL,
  `length` double(3,2) NOT NULL,
  `roleId` int(9) NOT NULL,
  `username` varchar(24) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `password` varchar(24) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

TRUNCATE TABLE `profile`;
INSERT INTO `profile` VALUES(1, 'Georgi', 'Atanasov', 21, 95.60, 1.87, 1, 'georgi', 'atanasov');
INSERT INTO `profile` VALUES(2, 'Karel', 'de Kleine', 24, 85.80, 1.78, 2, 'karel', 'dekleine');
INSERT INTO `profile` VALUES(3, 'Kimberlyn', 'Colenbrander', 20, 70.00, 1.80, 1, '', '');

CREATE TABLE `role` (
  `id` int(9) NOT NULL,
  `name` varchar(24) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

TRUNCATE TABLE `role`;
INSERT INTO `role` VALUES(1, 'zorgverlener');
INSERT INTO `role` VALUES(2, 'patient');

CREATE TABLE `weightregistration` (
  `id` int(9) NOT NULL,
  `profileId` int(9) NOT NULL,
  `date` date NOT NULL,
  `time` time NOT NULL,
  `weight` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

TRUNCATE TABLE `weightregistration`;
INSERT INTO `weightregistration` VALUES(3, 2, '2020-03-05', '16:00:00', 87.3);
INSERT INTO `weightregistration` VALUES(5, 1, '2020-03-03', '19:00:00', 80.3);
INSERT INTO `weightregistration` VALUES(7, 1, '2020-03-07', '19:00:00', 95);
INSERT INTO `weightregistration` VALUES(8, 1, '2020-03-08', '19:00:00', 76);
INSERT INTO `weightregistration` VALUES(9, 1, '2020-03-20', '19:00:00', 100.3);


ALTER TABLE `drug`
  ADD PRIMARY KEY (`id`);

ALTER TABLE `drugprescription`
  ADD PRIMARY KEY (`drugId`,`profileId`),
  ADD KEY `profileId` (`profileId`);

ALTER TABLE `profile`
  ADD PRIMARY KEY (`id`),
  ADD KEY `roleId` (`roleId`);

ALTER TABLE `role`
  ADD PRIMARY KEY (`id`);

ALTER TABLE `weightregistration`
  ADD PRIMARY KEY (`id`),
  ADD KEY `weightregistrationProfileId` (`profileId`);


ALTER TABLE `drug`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

ALTER TABLE `profile`
  MODIFY `id` int(9) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

ALTER TABLE `role`
  MODIFY `id` int(9) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

ALTER TABLE `weightregistration`
  MODIFY `id` int(9) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;


ALTER TABLE `drugprescription`
  ADD CONSTRAINT `drugId` FOREIGN KEY (`drugId`) REFERENCES `drug` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `profileId` FOREIGN KEY (`profileId`) REFERENCES `profile` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE `profile`
  ADD CONSTRAINT `roleId` FOREIGN KEY (`roleId`) REFERENCES `role` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

ALTER TABLE `weightregistration`
  ADD CONSTRAINT `weightregistrationProfileId` FOREIGN KEY (`profileId`) REFERENCES `profile` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
