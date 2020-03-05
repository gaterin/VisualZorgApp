-- phpMyAdmin SQL Dump
-- version 4.8.3
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Mar 05, 2020 at 11:48 PM
-- Server version: 10.1.35-MariaDB
-- PHP Version: 7.2.9

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `zorgapp`
--

-- --------------------------------------------------------

--
-- Table structure for table `drug`
--

CREATE TABLE `drug` (
  `id` int(11) NOT NULL,
  `name` varchar(24) NOT NULL,
  `description` text NOT NULL,
  `type` varchar(24) NOT NULL,
  `dosage` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `drug`
--

INSERT INTO `drug` (`id`, `name`, `description`, `type`, `dosage`) VALUES
(1, 'paracetamol', 'paracetamol description', 'pill', 'paracetamol dosage '),
(2, 'aspirine', 'aspirine discription', 'powder', 'aspirine dosage');

-- --------------------------------------------------------

--
-- Table structure for table `drugprescription`
--

CREATE TABLE `drugprescription` (
  `drugId` int(11) NOT NULL,
  `profileId` int(11) NOT NULL,
  `startDate` date NOT NULL,
  `endDate` date NOT NULL,
  `intakeTime` time NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `drugprescription`
--

INSERT INTO `drugprescription` (`drugId`, `profileId`, `startDate`, `endDate`, `intakeTime`) VALUES
(1, 1, '2020-02-26', '2020-03-06', '23:00:00'),
(2, 1, '2020-02-27', '2020-03-06', '23:00:00'),
(2, 2, '2020-02-27', '2020-02-28', '12:00:00');

-- --------------------------------------------------------

--
-- Table structure for table `profile`
--

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

--
-- Dumping data for table `profile`
--

INSERT INTO `profile` (`id`, `name`, `surname`, `age`, `weight`, `length`, `roleId`, `username`, `password`) VALUES
(1, 'Georgi', 'Atanasov', 21, 95.60, 1.87, 1, 'georgi', 'atanasov'),
(2, 'Karel', 'de Kleine', 24, 85.80, 1.78, 2, 'karel', 'dekleine');

-- --------------------------------------------------------

--
-- Table structure for table `role`
--

CREATE TABLE `role` (
  `id` int(9) NOT NULL,
  `name` varchar(24) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `role`
--

INSERT INTO `role` (`id`, `name`) VALUES
(1, 'zorgverlener'),
(2, 'patient');

-- --------------------------------------------------------

--
-- Table structure for table `weightregistration`
--

CREATE TABLE `weightregistration` (
  `id` int(9) NOT NULL,
  `profileId` int(9) NOT NULL,
  `date` date NOT NULL,
  `weight` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `weightregistration`
--

INSERT INTO `weightregistration` (`id`, `profileId`, `date`, `weight`) VALUES
(1, 1, '2020-03-05', 95.6),
(2, 1, '2020-03-04', 95.3),
(3, 2, '2020-03-05', 87.3);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `drug`
--
ALTER TABLE `drug`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `drugprescription`
--
ALTER TABLE `drugprescription`
  ADD PRIMARY KEY (`drugId`,`profileId`),
  ADD KEY `profileId` (`profileId`);

--
-- Indexes for table `profile`
--
ALTER TABLE `profile`
  ADD PRIMARY KEY (`id`),
  ADD KEY `roleId` (`roleId`);

--
-- Indexes for table `role`
--
ALTER TABLE `role`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `weightregistration`
--
ALTER TABLE `weightregistration`
  ADD PRIMARY KEY (`id`),
  ADD KEY `weightregistrationProfileId` (`profileId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `drug`
--
ALTER TABLE `drug`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `profile`
--
ALTER TABLE `profile`
  MODIFY `id` int(9) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `role`
--
ALTER TABLE `role`
  MODIFY `id` int(9) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `weightregistration`
--
ALTER TABLE `weightregistration`
  MODIFY `id` int(9) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `drugprescription`
--
ALTER TABLE `drugprescription`
  ADD CONSTRAINT `drugId` FOREIGN KEY (`drugId`) REFERENCES `drug` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `profileId` FOREIGN KEY (`profileId`) REFERENCES `profile` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `profile`
--
ALTER TABLE `profile`
  ADD CONSTRAINT `roleId` FOREIGN KEY (`roleId`) REFERENCES `role` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `weightregistration`
--
ALTER TABLE `weightregistration`
  ADD CONSTRAINT `weightregistrationProfileId` FOREIGN KEY (`profileId`) REFERENCES `profile` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
