document.addEventListener("DOMContentLoaded", function () {
    const brothsSelect = document.getElementById("broths");
    const proteinsSelect = document.getElementById("proteins");
    const orderButton = document.getElementById("orderButton");
    const orderResult = document.getElementById("orderResult");

    async function fetchOptions() {
        const brothsResponse = await fetch('http://localhost:5000/api/menu/broths');
        const broths = await brothsResponse.json();
        broths.forEach(broth => {
            const option = document.createElement("option");
            option.value = broth.id;
            option.textContent = broth.name;
            brothsSelect.appendChild(option);
        });

        const proteinsResponse = await fetch('http://localhost:5000/api/menu/proteins');
        const proteins = await proteinsResponse.json();
        proteins.forEach(protein => {
            const option = document.createElement("option");
            option.value = protein.id;
            option.textContent = protein.name;
            proteinsSelect.appendChild(option);
        });
    }

    orderButton.addEventListener("click", async function () {
        const selectedBroth = brothsSelect.value;
        const selectedProtein = proteinsSelect.value;

        const response = await fetch('http://localhost:5000/api/order', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ brothId: selectedBroth, proteinId: selectedProtein })
        });

        const result = await response.json();
        orderResult.textContent = `Pedido realizado com sucesso! Código do pedido: ${result.orderId}`;
    });

    fetchOptions();
});
