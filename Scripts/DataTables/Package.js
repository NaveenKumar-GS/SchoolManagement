
let Bronze = 0, Silver = 0, Gold = 0, Platinum = 0;



function returnData() {
    let packageValueSum = 0;// , licenseRateSum = 0;
    
    let bronzeActualRate = Bronze * 1000.00;
    let silverActualRate = Silver * 820.00;
    let goldActualRate = Gold * 735.00;
    let platinumActualRate = Platinum * 600.00;

    packageValueSum = Bronze + Silver + Gold + Platinum;
   /* licenseRateSum = 1000.00 + 820.00 + 735.00 + 600.00;*/
    actualLicenseRateSum = bronzeActualRate + silverActualRate + goldActualRate + platinumActualRate;

    let packageDetails = [];

    if (Bronze > 0) {
        packageDetails.push({ 'packageName': 'Bronze', 'packageValue': Bronze, 'Discount': 0.00, 'LicenseRate': 1000.00, 'ActualLicenseRate': bronzeActualRate });
    }

    if (Silver > 0) {
        packageDetails.push({ 'packageName': 'Silver', 'packageValue': Silver, 'Discount': 18.00, 'LicenseRate': 820.00, 'ActualLicenseRate': silverActualRate });
    }

    if (Gold > 0) {
        packageDetails.push({ 'packageName': 'Gold', 'packageValue': Gold, 'Discount': 26.50, 'LicenseRate': 735.00, 'ActualLicenseRate': goldActualRate });
    }

    if (Platinum > 0) {
        packageDetails.push({ 'packageName': 'Platinum', 'packageValue': Platinum, 'Discount': 40.00, 'LicenseRate': 600.00, 'ActualLicenseRate': platinumActualRate });
    }


    console.log('before pushing ');

    console.log(packageDetails);

    return {
        'packageDetails': packageDetails,
        'packageValueSum': packageValueSum,
        //'licenseRateSum': licenseRateSum
        'actualLicenseRateSum': actualLicenseRateSum
    }
}

function CaliberatePackage(packageVal) {
    Bronze = 0, Silver = 0, Gold = 0, Platinum = 0;
    packageValue = packageVal;
  
    // BRONZE CASE

    if (packageValue <= 10) {
        Bronze = packageValue;
        var t = returnData();
        return t;

    }

    // SILVER CASE

    if (packageValue >= 11 && packageValue <= 25) {
        Bronze = 10;
        packageValue -= 10;
        if (packageValue <= 25) {
            Silver = packageValue;
            packageValue -= 5;
        }
        //return [
        //    { 'packageName': 'bronze', 'packageValue': bronze, 'Discount': 0.00, 'LicenseRate': 1000.00 },
        //    { 'packageName': 'silver', 'packageValue': silver, 'Discount': 18.00, 'LicenseRate': 820.00 },
        //    { 'packageName': 'gold', 'packageValue': gold, 'Discount': 26.50, 'LicenseRate': 735.00 },
        //    { 'packageName': 'platinum', 'packageValue': platinum, 'Discount': 40.00, 'LicenseRate': 600.00 }
        //];
        var t = returnData();
        return t;

    }

    // GOLD CASE

    if (packageValue >= 26 && packageValue <= 40) {
        Bronze = 10;
        packageValue -= 10;
        if (packageValue <= 25) {
            Silver = packageValue;

        }
        if (packageValue > 25) {
            Silver = 25;
            packageValue -= 25;
            if (packageValue <= 15) {
                Gold = packageValue;
            }
            if (packageValue > 15) {
                Gold = 15;
                packageValue -= 15;
            }
        }
        //return [
        //    { 'packageName': 'bronze', 'packageValue': bronze, 'Discount': 0.00, 'LicenseRate': 1000.00 },
        //    { 'packageName': 'silver', 'packageValue': silver, 'Discount': 18.00, 'LicenseRate': 820.00 },
        //    { 'packageName': 'gold', 'packageValue': gold, 'Discount': 26.50, 'LicenseRate': 735.00 },
        //    { 'packageName': 'platinum', 'packageValue': platinum, 'Discount': 40.00, 'LicenseRate': 600.00 }
        //];
        var t = returnData();
        return t;

    }

    // PLATINUM CASE

    if (packageValue > 40) {
        Bronze = 10;
        packageValue -= 10;
        if (packageValue <= 25) {
            Silver = packageValue;

        }
        if (packageValue >= 25) {
            Silver = 25;
            packageValue -= 25;
            if (packageValue <= 40) {
                Gold = packageValue;
            }

            if (packageValue >= 40) {

                Gold = 40;
                packageValue -= 40;
                Platinum = packageValue;

            }
        }
        //return [
        //    { 'packageName': 'bronze', 'packageValue': bronze, 'Discount': 0.00, 'LicenseRate': 1000.00 },
        //    { 'packageName': 'silver', 'packageValue': silver, 'Discount': 18.00, 'LicenseRate': 820.00 },
        //    { 'packageName': 'gold', 'packageValue': gold, 'Discount': 26.50, 'LicenseRate': 735.00 },
        //    { 'packageName': 'platinum', 'packageValue': platinum, 'Discount': 40.00, 'LicenseRate': 600.00 }
        //];
        var t = returnData();
        return t;

    }
}
