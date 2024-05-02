<script setup>
import { onMounted, ref } from "vue";
import { getLegalContract, updateLegalContract } from "../../api/legalContracts.api.js";
import { useRoute, useRouter } from "vue-router";
import moment from "moment";

const route = useRoute();
const router = useRouter();

const legalContract = ref([]);

onMounted(async () => {
  const [getLegalContractError, legalContractResponse] = await getLegalContract(
    route.params.id
  );

  if (getLegalContractError) {
    console.error(getLegalContractError);
  } else {
    legalContract.value = legalContractResponse;
  }
});

const updateLegalContractClick = async () => {
  const [updateLegalContractError, updateLegalContractResponse] = await updateLegalContract(
    legalContract.value
  );

  if (updateLegalContractError) {
    console.error(updateLegalContractError);
  } else {
    router.push({ name: "legal-contract", params: { id: legalContract.value.id }})
  }
};
</script>

<template>
  <div class="inline-flex pr-auto">
    <router-link
      to="/"
      class="block transition-colors hover:bg-blue-900 bg-blue-800 text-white px-4 py-2 rounded-lg"
    >
      Back
    </router-link>
  </div>
  <section class="flex flex-col flex-1 justify-center gap-8">
    <Suspense>
      <div
        class="grid grid-cols-2 grid-flow-row items-end justify-start gap-y-4"
        v-if="legalContract"
      >
        <div class="font-bold text-2xl">Title:</div>
        <input
          v-model="legalContract.title"
          type="text"
          class="shadow appearance-none border rounded w-full py-2 px-3 text-white leading-tight focus:outline-none focus:shadow-outline"
        />
        <div class="font-bold text-2xl">Author:</div>
        <input
          v-model="legalContract.author"
          type="text"
          class="shadow appearance-none border rounded w-full py-2 px-3 text-white leading-tight focus:outline-none focus:shadow-outline"
        />
        <div class="font-bold text-2xl">Content:</div>
        <textarea
          v-model="legalContract.content"
          rows="20"
          class="shadow appearance-none border rounded w-full py-2 px-3 text-white leading-tight focus:outline-none focus:shadow-outline"
        />
      </div>
      <template #fallback>
        <div class="text-white text-4xl">Loading...</div>
      </template>
    </Suspense>
    <div class="flex flex-row gap-x-4 justify-end">
      <button
        @click="updateLegalContractClick"
        class="block transition-colors hover:bg-blue-900 bg-blue-800 text-white px-4 py-2 rounded-lg"
      >
        Update
      </button>
    </div>
  </section>
</template>
