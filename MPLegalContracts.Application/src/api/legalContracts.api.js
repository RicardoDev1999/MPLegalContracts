import axios from "axios";

//Base url should go to an .env file but for the sake of simplicity I will leave it here
const axiosClient = axios.create({
  baseURL: "https://localhost:7242/legal-contracts",
});

export async function getLegalContracts() {
  try {
    const { data } = await axiosClient.get("/");
    return [null, data];
  } catch (error) {
    return [error];
  }
}

export async function getLegalContract(id) {
  try {
    const { data } = await axiosClient.get(`/${id}`);
    return [null, data];
  } catch (error) {
    return [error];
  }
}

export async function addLegalContract(model) {
  try {
    const { data } = await axiosClient.post("/", JSON.stringify(model), {
      headers: {
        "Content-Type": "application/json",
      },
    });
    return [null, data];
  } catch (error) {
    return [error];
  }
}

export async function updateLegalContract(model) {
  try {
    const { data } = await axiosClient.put("/", model , {
      headers: {
        "Content-Type": "application/json",
      },
    });
    return [null, data];
  } catch (error) {
    return [error];
  }
}

export async function deleteLegalContract(id) {
  try {
    const { data } = await axiosClient.delete(`/${id}`);
    return [null, data];
  } catch (error) {
    return [error];
  }
}
