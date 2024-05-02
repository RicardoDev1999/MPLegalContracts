<script setup>
import { onMounted, ref } from "vue";
import { getLegalContracts } from "../api/legalContracts.api.js";

const legalContracts = ref([]);

onMounted(async () => {
  const [getLegalContractsError, legalContractsResponse] =
    await getLegalContracts();

  if (getLegalContractsError) {
    console.error(getLegalContractsError);
  } else {
    legalContracts.value = legalContractsResponse;
  }
});
</script>

<template>
  <section class="flex flex-col flex-1 items-center justify-center gap-8">
    <h1 class="text-white text-2xl">Legal Contracts</h1>
    <Suspense>
      <div class="grid grid-flow-row-dense grid-cols-3 gap-4">
        <div
          v-if="legalContracts"
          v-for="item in legalContracts"
          :key="item.id"
        >
          <router-link
            :to="{ name: 'legal-contract', params: { id: item.id } }"
            class="block max-w-sm p-6 borderrounded-lg shadow bg-gray-800 border-gray-700 hover:bg-gray-700"
          >
            <h5 class="mb-2 text-2xl font-bold tracking-tight text-white">
              {{ item.title }}
            </h5>
            <p class="font-bold text-gray-400">
              {{ item.author }}
            </p>
            <p class="font-normal text-gray-400">
              {{ item.content }}
            </p>
          </router-link>
        </div>
      </div>
      <template #fallback>
        <div class="text-white text-4xl">Loading...</div>
      </template>
    </Suspense>
    <div class="flex flex-col justify-center gap-y-4 mt-20">
      <router-link
        :to="{ name: 'legal-contract-add' }"
        class="block mx-auto transition-colors hover:bg-blue-900 bg-blue-800 text-white px-4 py-2 rounded-lg"
      >
        Add
      </router-link>
    </div>
  </section>
</template>
