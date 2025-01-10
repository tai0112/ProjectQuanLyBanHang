const formatVND = (amount) => {
    return new Intl.NumberFormat('vi-VN', {
        style: 'currency',
        currency: 'VND',
    }).format(amount);
};

const formarSsd = (gb) => {
    if (gb > 1000) {
        gb = gb / 1024;
        return `${gb.toFixed(0)}TB`
    } else {
        return `${gb}GB`
    }
}

$('.ssd').each(function () {
    const gb = parseInt(this.innerText);
    $(this).text(formarSsd(gb));
});

$('.price').each(function () {
    const amount = parseFloat($(this).text().replace(/\D/g, '')) || 0; // Extract numeric value
    $(this).text(formatVND(amount));
});